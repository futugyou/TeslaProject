
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
                o.QueryDelay = TimeSpan.FromSeconds(1);

                o.UseMySql();
                o.UseBusOutbox();
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
        _logger.LogInformation("Value: {Value}", context.Message.Value);
    }
}

public record TeslaEvent
{
    public string? Value { get; internal set; }
}


public class MassTransitOptions
{
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

}