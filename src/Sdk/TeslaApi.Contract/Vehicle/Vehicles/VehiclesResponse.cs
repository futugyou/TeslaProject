using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Vehicles;

public class VehiclesResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public VehicleDetail[] Response { get; set; }
    [JsonPropertyName("count")]
    public int? Count { get; set; }
}