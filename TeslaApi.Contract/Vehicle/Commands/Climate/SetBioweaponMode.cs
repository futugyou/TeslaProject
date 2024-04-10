
using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Climate;
public class SetBioweaponModeRequest
{
    [JsonPropertyName("on")]
    public bool On { get; set; }
}