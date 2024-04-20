using Domain;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using TeslaApi.Abstractions;
using TeslaApi.Contract;

namespace Api;

public static class VehicleEndpoints
{
    public static void Map(WebApplication app)
    {
        var vehicleGroup = app.MapGroup("/vehicle")
        .WithName("vehicle")
        .WithOpenApi();

        vehicleGroup.MapGet("/{vin}", VehicleInfo);
        vehicleGroup.MapGet("/{vin}/state", VehicleState);
        vehicleGroup.MapPost("/{vin}/ws", VehicleWebSocket);
    }

    static async Task<IResult> VehicleInfo([FromServices] IVehicleRepository repo, string vin)
    {
        var vehicle = await repo.GetByVin(vin);
        if (vehicle == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(vehicle);
    }

    static async Task<IResult> VehicleState([FromServices] IVehicleRepository repo, IVehicleState state, string vin)
    {
        var vehicle = await repo.GetByVin(vin);
        if (vehicle == null)
        {
            return TypedResults.NotFound();
        }

        var token = "";//TODO get token
        var vehicleState = await state.GetUserVehicleById(vehicle.Vid.ToString(), token);

        // TODO: store the data
        if (vehicleState == null || vehicleState.Response == null)
        {
            return TypedResults.NotFound();
        }

        if (vehicleState.Response.State != "online")
        {
            return TypedResults.Ok(vehicleState.Response);
        }

        // TODO: call this api may wakeup car, need some limit
        // TODO: store the data
        var vehicleData = await state.GetVehicleData(vehicle.Vid.ToString(), token);
        return TypedResults.Ok(vehicleData?.Response);
    }

    static async Task<IResult> VehicleWebSocket([FromServices] IVehicleRepository repo, [FromServices] IBackgroundTaskQueue queue, string vin)
    {
        var vehicle = await repo.GetByVin(vin);
        if (vehicle == null)
        {
            return TypedResults.NotFound();
        }

        var token = "";//TODO get token
        StreamRequest rquest = new()
        {
            VinID = vehicle.Vid,
            Token = token,
        };
        var pararmeter = new TaskQueueParameter
        {
            IdentityKey = vin,
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
        var redis = scope.ServiceProvider.GetRequiredService<IRedisClient>();
        var _logger = scope.ServiceProvider.GetRequiredService<ILogger<ITeslaStream>>();
        await teslaStream.StartAsync(stoppingToken);

        StreamRequest rquest = (StreamRequest)state;
        try
        {
            await teslaStream.ReceiveAsync(rquest, stoppingToken);
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message}", ex.Message);
        }
        finally
        {
            await redis.UnLock(rquest.Vin, rquest.Vin);
        }

        await teslaStream.StopAsync(stoppingToken);
    }

}