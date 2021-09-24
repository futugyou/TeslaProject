using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeslaApi.Vehicle;
using TeslaApi.Vehicle.Abstractions;
using TeslaApi.Authentication;
using TeslaApi.Authentication.Abstractions;
using TeslaApi.Contract;

namespace TeslaApi.Extensions.DependencyInjection;
public static class DependencyInjectionExtensions
{
    public static readonly string TESLA_AUTH_OPTION_KEY = "TeslaAuth";
    public static readonly string TESLA_VEHICLE_OPTION_KEY = "TeslaVehicle";

    public static IServiceCollection AddTeslaApiLibary(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        return services.AddTeslaApiLibary(configuration);
    }

    public static IServiceCollection AddTeslaApiLibary(this IServiceCollection services, IConfiguration configuration)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }
        services.Configure<AuthenticationOptions>(configuration.GetSection(TESLA_AUTH_OPTION_KEY));
        services.Configure<VehicleOptions>(configuration.GetSection(TESLA_VEHICLE_OPTION_KEY));

        services.AddHttpClient(TeslaApiConst.TESLA_HTTPCLIENT_NAME);

        services.AddScoped<ITeslaAuthentication, TeslaAuthentication>();
        services.AddScoped<IVehicleCommand, VehicleCommand>();
        services.AddScoped<IVehicleState, VehicleState>();
        services.AddScoped<IVehicleUser, VehicleUser>();
        return services;
    }
}
