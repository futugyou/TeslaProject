
using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Climate;
public class RemoteSeatCoolerRequest
{

    /// <summary>
    /// The desired seat to cool. (0-5)
    /// </summary>
    [JsonPropertyName("seat_position")]
    public int SeatPosition { get; set; }
    /// <summary>
    /// The desired level for the cooler. (0-3)
    /// </summary>
    [JsonPropertyName("seat_cooler_level")]
    public int SeatCoolerLevel { get; set; }
}