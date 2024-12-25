
namespace TeslaApi.Contract.Vehicle.Commands.Media;

public class AdjustVolumeRequest
{
    [JsonPropertyName("volume")]
    public int Volume { get; set; }
}
