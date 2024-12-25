
namespace TeslaApi.Contract.Vehicle.Commands.Charging;

public class SetChargingAmpsRequest
{
    [JsonPropertyName("charging_amps")]
    public int  ChargingAmps { get; set; }
}
