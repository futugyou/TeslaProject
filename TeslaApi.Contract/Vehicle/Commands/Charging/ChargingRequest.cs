using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Charging;

public class ChargingRequest
{
    [JsonPropertyName("percent")]
    public int? Percent { get; set; }
}
