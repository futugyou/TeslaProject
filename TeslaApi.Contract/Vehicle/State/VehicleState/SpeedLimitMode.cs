using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.VehicleState;

public class SpeedLimitMode
{
    [JsonPropertyName("active")]
    public bool Active { get; set; }
    [JsonPropertyName("current_limit_mph")]
    public float CurrentLimitMph { get; set; }
    [JsonPropertyName("max_limit_mph")]
    public int? MaxLimitMph { get; set; }
    [JsonPropertyName("min_limit_mph")]
    public object MinLimitMph { get; set; }
    [JsonPropertyName("pin_code_set")]
    public bool PinCodeSet { get; set; }
}