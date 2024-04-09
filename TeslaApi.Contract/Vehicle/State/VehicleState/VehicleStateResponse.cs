using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.VehicleState;

public class VehicleStateResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public VehicleStateDetail Response { get; set; }
}
