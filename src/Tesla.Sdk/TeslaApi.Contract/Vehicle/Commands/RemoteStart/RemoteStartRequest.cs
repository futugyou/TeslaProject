
namespace TeslaApi.Contract.Vehicle.Commands.RemoteStart;

public class RemoteStartRequest
{
    [JsonPropertyName("password")]
    public string Password { get; set; }
}
