
namespace TeslaApi.Contract.Vehicle.Commands.Climate;

public class SetTempsRequest
{
    [JsonPropertyName("driver_temp")]
    public float DriverTemp { get; set; }
    [JsonPropertyName("passenger_temp")]
    public float PassengerTemp { get; set; }
}
