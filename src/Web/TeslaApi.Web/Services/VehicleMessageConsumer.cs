using Domain;
using MassTransit;

namespace Services;

public class VehicleMessageConsumer : IConsumer<VehicleMessage>
{
    private readonly ILogger<VehicleMessageConsumer> _logger;

    public VehicleMessageConsumer(ILogger<VehicleMessageConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<VehicleMessage> context)
    {
        _logger.LogError("Value: {Value}", context.Message.Raw);
    }
}
