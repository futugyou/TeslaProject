
namespace TeslaApi.Contract.Vehicle.State.Data;


public class VehicleStateDataResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public VehicleDataDetail Response { get; set; }
}