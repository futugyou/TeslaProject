using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.VehicleConfig;

public class VehicleConfigResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public VehicleConfigDetail Response { get; set; }
}
