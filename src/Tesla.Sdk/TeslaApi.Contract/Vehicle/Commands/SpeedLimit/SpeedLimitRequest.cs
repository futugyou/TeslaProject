
namespace TeslaApi.Contract.Vehicle.Commands.SpeedLimit;

public class SpeedLimitRequest
{
    [JsonPropertyName("limit_mph")]
    public int LimitMph { get; set; }
}
public class SpeedLimitWithPinRequest
{
    [JsonPropertyName("pin")]
    public string Pin { get; set; }
}
