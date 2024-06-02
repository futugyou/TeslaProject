
using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Climate;
public class RemoteAutoSeatClimateRequest
{
    [JsonPropertyName("auto_seat_position")]
    public int AutoSeatPosition { get; set; }
    [JsonPropertyName("auto_climate_on")]
    public bool AutoClimateOn { get; set; }
}