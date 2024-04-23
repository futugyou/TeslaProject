using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using TeslaApi.Abstractions;

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

        services.AddRefitClient< ITeslaAuthentication>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://auth.tesla.com"));


        var clientBuilder = services.AddRefitClient<IUser>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://owner-api.teslamotors.com"));

        clientBuilderOption?.Invoke(clientBuilder);
        clientBuilder.AddHttpMessageHandler<EndpointChangeHandler>();
        return services;
    }

}
