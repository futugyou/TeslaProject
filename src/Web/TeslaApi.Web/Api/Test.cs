using Microsoft.AspNetCore.Mvc;
using TeslaApi.SDK;
using TeslaApi.Contract;
using TeslaApi.Contract.Authentication;
using Extensions;

namespace Api;

public static class TestEndpoints
{
    public static void UseTestEndpoints(this IEndpointRouteBuilder app)
    {
        var vehicleGroup = app.MapGroup("/test")
                .WithName("test")
                .WithOpenApi();

        vehicleGroup.MapGet("/token", AccessToken).WithName("token");
        vehicleGroup.MapGet("/user", UserInfo).WithName("user");
        vehicleGroup.MapGet("/tokeninfo", LocalInfo).WithName("tokeninfo");
        vehicleGroup.MapGet("/ws", VehicleWebSocket).WithName("wstest");
        vehicleGroup.MapGet("/vehicle", VehicleInfo).WithName("vehicletest");
    }

    static async Task<IResult> VehicleInfo([FromServices] IVehicleState state, [FromQuery] string vid, [FromQuery] string token)
    {
        var vehicleState = await state.GetUserVehicleById(vid, token);
        if (vehicleState == null || vehicleState.Response == null)
        {
            return TypedResults.NotFound();
        }

        if (vehicleState.Response.State != "online")
        {
            return TypedResults.Ok(vehicleState.Response);
        }

        var vehicleData = await state.GetVehicleData(vid, token);
        return TypedResults.Ok(vehicleData?.Response);
    }

    static async Task<IResult> AccessToken([FromServices] ITeslaAuthentication tesla, [FromQuery] string code, [FromQuery] string verifier)
    {
        var request = new AccessTokenRequest
        {
            Code = code,
            CodeVerifier = verifier,
        };

        var result = await tesla.GetAccessToken(request);
        return TypedResults.Ok(result);
    }

    static async Task<IResult> UserInfo([FromServices] IUser tesla, [FromQuery] string token)
    {
        var result = await tesla.UserInformation(token);
        return TypedResults.Ok(result);
    }

    static Microsoft.AspNetCore.Http.HttpResults.Ok<TokenInfo> LocalInfo([FromQuery] string token)
    {
        var result = new TokenInfo(token);
        return TypedResults.Ok(result);
    }

    static async Task<IResult> VehicleWebSocket([FromServices] IBackgroundTaskQueue queue, [FromQuery] string token, [FromQuery] string vid)
    {
        StreamRequest rquest = new()
        {
            VinID = int.Parse(vid),
            Token = token,
        };
        var pararmeter = new TaskQueueParameter
        {
            IdentityKey = vid,
            Parameter = rquest,
        };
        // send to queue
        await queue.QueueBackgroundWorkItemAsync(ConnectVehicleStream, pararmeter);
        return TypedResults.Ok();
    }

    static async ValueTask ConnectVehicleStream(IServiceProvider sp, object state, CancellationToken stoppingToken)
    {
        using var scope = sp.CreateScope();
        var teslaStream = scope.ServiceProvider.GetRequiredService<ITeslaStream>();
        var _logger = scope.ServiceProvider.GetRequiredService<ILogger<ITeslaStream>>();

        StreamRequest rquest = (StreamRequest)state;
        try
        {
            await teslaStream.StartAsync(rquest, stoppingToken);
            while (await teslaStream.MessageReader.WaitToReadAsync(stoppingToken))
            {
                var msg = await teslaStream.MessageReader.ReadAsync(stoppingToken);
                _logger.LogInformation("test {Message}", msg?.Value);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message}", ex.Message);
        }
        finally
        {
            await teslaStream.StopAsync(stoppingToken);
        }
    }
}