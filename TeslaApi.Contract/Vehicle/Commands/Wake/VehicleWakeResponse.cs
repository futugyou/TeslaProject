using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Wake;

public class VehicleWakeResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public VehicleWakeDetail Response { get; set; }
}