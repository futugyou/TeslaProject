
using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Climate;
public class SetClimateKeeperModeRequest
{
    [JsonPropertyName("climate_keeper_mode")]
    public int ClimateKeeperMode { get; set; }
}