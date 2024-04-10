using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TeslaApi.Authentication;
using TeslaApi.Authentication.Abstractions;
using TeslaApi.Contract;
using TeslaApi.Storage;
using TeslaApi.Storage.Abstractions;
using TeslaApi.Vehicle;
using TeslaApi.Vehicle.Abstractions;

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
        services.AddTransient<AuthHeaderHandler>();

        services.AddHttpClient(TeslaApiConst.TESLA_AUTH_HTTPCLIENT_NAME, (sp, client) =>
        {

        });

        services.AddHttpClient(TeslaApiConst.TESLA_SERVICE_HTTPCLIENT_NAME, (sp, client) =>
        {
            var _optionsMonitor = sp.GetRequiredService<IOptionsMonitor<VehicleOptions>>();
            var _options = _optionsMonitor.CurrentValue;
            if (_options == null)
            {
                throw new ArgumentNullException(nameof(VehicleOptions));
            }
            client.BaseAddress = new Uri(_options.TeslaBaseUrl);
        });
        // TODO wait for token readly
        //.AddHttpMessageHandler<AuthHeaderHandler>();

        services.AddScoped<ITeslaAuthentication, TeslaAuthentication>();
        services.AddScoped<IVehicleCommand, VehicleCommand>();
        services.AddScoped<IVehicleState, VehicleState>();
        services.AddScoped<ITeslaUserAuthInfoRepository, DefaultTeslaUserAuthInfoRepository>();
        return services;
    }
}
