

namespace TeslaApi.Contract.Vehicle.Commands.Climate;
public class SetCabinOverheatProtectionRequest
{
    [JsonPropertyName("fan_only")]
    public bool FanOnly { get; set; }
    [JsonPropertyName("on")]
    public bool On { get; set; }
}