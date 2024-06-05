using Domain;
using TeslaApi.Contract;
using TeslaApi.SDK;

namespace Services;

public interface IVehicleMessage
{
    Task HandleVehicleMessage(StreamRequest message, CancellationToken stoppingToken);
}

public class VehicleMessage : IVehicleMessage
{
    private readonly ISocketDataRepository _repository;
    private readonly ITeslaStream _teslaStream;
    private readonly ILogger<VehicleMessage> _logger;

    public VehicleMessage(ILogger<VehicleMessage> logger, ISocketDataRepository repository, ITeslaStream teslaStream)
    {
        _repository = repository;
        _teslaStream = teslaStream;
        _logger = logger;
    }

    public async Task HandleVehicleMessage(StreamRequest message, CancellationToken stoppingToken)
    {
        try
        {
            await _teslaStream.StartAsync(message, stoppingToken);
            while (await _teslaStream.MessageReader.WaitToReadAsync(stoppingToken))
            {
                var msg = await _teslaStream.MessageReader.ReadAsync(stoppingToken);
                _logger.LogInformation("{Message}", msg?.Value);
                var data = new SocketData
                {
                    VinID = message.VinID,
                    Vin = message.Vin,
                    UserID = message.UserID,
                    Raw = msg?.Value ?? "",
                    InsertedAt = DateTime.UtcNow,
                };
                await _repository.Add(data);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message}", ex.Message);
        }
        finally
        {
            await _teslaStream.StopAsync(stoppingToken);
        }
    }
}
