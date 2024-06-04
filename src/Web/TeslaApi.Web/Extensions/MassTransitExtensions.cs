
using Infrastruct;
using MassTransit;

namespace Extensions;

public static class MassTransitExtensions
{
    public static IServiceCollection AddMQMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MassTransitHostOptions>(options =>
        {
            options.WaitUntilStarted = true;
            options.StartTimeout = TimeSpan.FromSeconds(30);
            options.StopTimeout = TimeSpan.FromMinutes(1);
        });

        var option = new MassTransitOptions();
        configuration.GetSection("MassTransitOptions").Bind(option);

        services.AddMassTransit(x =>
        {
            x.AddEntityFrameworkOutbox<TeslaContext>(o =>
            {
                o.UseMySql();
                o.UseBusOutbox();
                // o.QueryDelay = TimeSpan.FromSeconds(1);
                o.QueryDelay = TimeSpan.FromSeconds(10);
                o.QueryTimeout = TimeSpan.FromSeconds(30);
                o.DuplicateDetectionWindow = TimeSpan.FromMinutes(30);
                o.DisableInboxCleanupService();
            });

            x.AddConsumer<TeslaEventConsumer>();

            x.SetKebabCaseEndpointNameFormatter();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(option.Host, h =>
                {
                    h.Username(option.Username);
                    h.Password(option.Password);
                });

                cfg.AutoStart = true;
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
public class TeslaEventConsumer : IConsumer<TeslaEvent>
{
    ILogger<TeslaEventConsumer> _logger;

    public TeslaEventConsumer(ILogger<TeslaEventConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<TeslaEvent> context)
    {
        _logger.LogError("Value: {Value}", context.Message.Value);
    }
}

public record TeslaEvent
{
    public string? Value { get; init; }
}


public class MassTransitOptions
{
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

}