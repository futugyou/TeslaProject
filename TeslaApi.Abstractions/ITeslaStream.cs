using TeslaApi.Contract;

namespace TeslaApi.Abstractions;

public interface ITeslaStream
{
    Task HandleMessage(TeslaStreamMessage message, CancellationToken cancellation); 
}