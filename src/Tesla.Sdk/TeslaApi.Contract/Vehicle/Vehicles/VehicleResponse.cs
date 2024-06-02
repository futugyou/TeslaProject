using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Vehicles;

public class VehicleResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public VehicleDetail Response { get; set; }
}
