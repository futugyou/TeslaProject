﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TeslaApi.Contract;
using TeslaApi.Storage;
using TeslaApi.Storage.Abstractions;
using TeslaApi.Abstractions;

namespace TeslaApi.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static readonly string TESLA_AUTH_OPTION_KEY = "TeslaAuth"; 
    public static readonly string TESLA_OPTION_KEY = "Tesla";

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
        services.Configure<TeslaOptions>(configuration.GetSection(TESLA_OPTION_KEY));
        services.AddTransient<AuthHeaderHandler>();
        services.AddTransient<EndpointChangeHandler>();

        services.AddHttpClient(TeslaApiConst.TESLA_AUTH_HTTPCLIENT_NAME, (sp, client) =>
        {

        });

        services.AddHttpClient(TeslaApiConst.TESLA_SERVICE_HTTPCLIENT_NAME, (sp, client) =>
        {
            var _optionsMonitor = sp.GetRequiredService<IOptionsMonitor<TeslaOptions>>();
            var _options = _optionsMonitor.CurrentValue;
            if (_options == null)
            {
                throw new ArgumentNullException(nameof(TeslaOptions));
            }
            client.BaseAddress = new Uri(_options.TeslaBaseUrl);
        })
        .AddHttpMessageHandler<EndpointChangeHandler>()
        ;
        // TODO wait for token readly
        //.AddHttpMessageHandler<AuthHeaderHandler>();

        services.AddScoped<ITeslaAuthentication, TeslaAuthentication>();
        services.AddScoped<IVehicleCommand, VehicleCommand>();
        services.AddTransient<ITeslaStream, TeslaStream>();
        services.AddScoped<IVehicleState, VehicleState>();
        services.AddScoped<IUser, User>();
        services.AddScoped<ITeslaUserAuthInfoRepository, DefaultTeslaUserAuthInfoRepository>();
        return services;
    }
}
