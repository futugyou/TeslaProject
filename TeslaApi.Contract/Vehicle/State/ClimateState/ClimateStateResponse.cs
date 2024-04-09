using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.ClimateState;

public class ClimateStateResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public ClimateStateDetail Response { get; set; }
}
