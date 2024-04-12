using TeslaApi.Contract;

namespace TeslaApi.Abstractions;

public interface ITeslaStream
{
    Task ReceiveAsync(StreamRequest rquest, CancellationToken cancellation = default);
    Task StartAsync(CancellationToken cancellationToken = default);
    Task StopAsync(CancellationToken cancellationToken = default);
    Task SendAsync(TeslaStreamMessage message, CancellationToken cancellationToken = default);
}