using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Charging;

public class SetScheduledChargingRequest
{
    [JsonPropertyName("enable")]
    public bool Enable { get; set; }
    [JsonPropertyName("time")]
    public int ChargingTime { get; set; }
}
