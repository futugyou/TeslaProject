using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Climate;

public class RemoteSeatHeaterRequest
{
    /// <summary>
    /// The desired seat to heat. (0-5)<see cref="HeaterType"/>
    /// </summary>
    [JsonPropertyName("heater")]
    public int Heater { get; set; }
    /// <summary>
    /// The desired level for the heater. (0-3)
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }
}

public enum HeaterType
{
    FrontLeft = 0,
    FrontRight = 1,
    RearLeft = 2,
    RearCenter = 4,
    RearRight = 5,
}
