namespace Extensions;

public static class MassTransitExtensions
{
    public static IServiceCollection ConfigMassTransit(this IServiceCollection services, IConfiguration configuration)
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
            x.AddConsumer<VehicleMessageConsumer>();

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

            x.AddRider(rider =>
           {
               rider.AddProducer<KafkaMessage>(option.RiderTopicName);
               rider.AddConsumer<KafkaMessageConsumer>();

               rider.UsingKafka((context, k) =>
               {
                   k.Host(option.RiderHost);

                   k.TopicEndpoint<KafkaMessage>(option.RiderTopicName, option.RiderGroupName, e =>
                   {
                       e.ConfigureConsumer<KafkaMessageConsumer>(context);
                   });
               });
           });
        });

        return services;
    }
}

public class MassTransitOptions
{
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string RiderHost { get; set; }
    public string RiderTopicName { get; set; }
    public string RiderGroupName { get; set; }
}

// demo consumer
public class TeslaEventConsumer : IConsumer<TeslaEvent>
{
    ILogger<TeslaEventConsumer> _logger;

    public TeslaEventConsumer(ILogger<TeslaEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<TeslaEvent> context)
    {
        _logger.LogError("rabbitmq consumer: Value: {Value}", context.Message.Value);
        return Task.CompletedTask;
    }
}

public record TeslaEvent
{
    public string? Value { get; init; }
}

class KafkaMessageConsumer : IConsumer<KafkaMessage>
{
    ILogger<KafkaMessageConsumer> _logger;

    public KafkaMessageConsumer(ILogger<KafkaMessageConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<KafkaMessage> context)
    {
        _logger.LogError("kafka consumer: Text: {Text}", context.Message.Text);
        return Task.CompletedTask;
    }
}

public record KafkaMessage
{
    public string Text { get; init; }
}
