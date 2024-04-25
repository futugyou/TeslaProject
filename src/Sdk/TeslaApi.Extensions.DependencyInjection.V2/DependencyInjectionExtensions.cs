using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using TeslaApi.SDK;

namespace TeslaApi.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static readonly string TESLA_AUTH_OPTION_KEY = "TeslaAuth";
    public static readonly string TESLA_OPTION_KEY = "Tesla";

    public static IServiceCollection AddTeslaApiLibary(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        return services.AddTeslaApiLibary(configuration);
    }

    public static IServiceCollection AddTeslaApiLibary(this IServiceCollection services, IConfiguration configuration, Action<IHttpClientBuilder> clientBuilderOption = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddTransient<EndpointChangeHandler>();

        services.AddRefitClient<ITeslaAuthentication>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://auth.tesla.com"));

        var vehicleInterfaces = typeof(IVehicleRefit).Assembly.GetTypes()
                    .Where(t => t.IsInterface && typeof(IVehicleRefit).IsAssignableFrom(t) && t != typeof(IVehicleRefit))
                    .ToList();

        foreach (var T in vehicleInterfaces)
        {
            var genericMethod = typeof(Refit.HttpClientFactoryExtensions).GetMethod("AddRefitClient", [typeof(IServiceCollection), typeof(RefitSettings)])?.MakeGenericMethod(T);
            if (genericMethod?.Invoke(null, [services, null]) is not IHttpClientBuilder builder)
            {
                continue;
            }

            builder.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://owner-api.teslamotors.com"));
            clientBuilderOption?.Invoke(builder);
            builder.AddHttpMessageHandler<EndpointChangeHandler>();
        }

        services.AddTransient<ITeslaStream, TeslaStream>();
        return services;
    }

}
