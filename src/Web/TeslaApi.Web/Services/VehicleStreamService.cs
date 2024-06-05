using Domain;
using MassTransit;
using TeslaApi.Contract;
using TeslaApi.SDK;

namespace Services;

public interface IVehicleStreamService
{
    Task HandleStreamRequest(StreamRequest message, CancellationToken stoppingToken);
}

public class VehicleStreamService : IVehicleStreamService
{
    private readonly IVehicleMessageRepository _repository;
    private readonly ITeslaStream _teslaStream;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VehicleStreamService> _logger;

    public VehicleStreamService(ILogger<VehicleStreamService> logger, IVehicleMessageRepository repository, ITeslaStream teslaStream, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _teslaStream = teslaStream;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task HandleStreamRequest(StreamRequest message, CancellationToken stoppingToken)
    {
        try
        {
            await _teslaStream.StartAsync(message, stoppingToken);
            while (await _teslaStream.MessageReader.WaitToReadAsync(stoppingToken))
            {
                var msg = await _teslaStream.MessageReader.ReadAsync(stoppingToken);
                _logger.LogInformation("{Message}", msg?.Value);
                var data = new VehicleMessage
                {
                    VinID = message.VinID,
                    Vin = message.Vin,
                    UserID = message.UserID,
                    Raw = msg?.Value ?? "",
                    InsertedAt = DateTime.UtcNow,
                };
                await _repository.Add(data);
                await _unitOfWork.CommitAsync(stoppingToken);
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
