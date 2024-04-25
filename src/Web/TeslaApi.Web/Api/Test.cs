using Microsoft.AspNetCore.Mvc;
using TeslaApi.SDK;
using TeslaApi.Contract;
using TeslaApi.Contract.Authentication;

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

}