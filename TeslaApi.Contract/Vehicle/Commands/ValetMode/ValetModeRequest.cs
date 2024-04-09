using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.ValetMode;

public class ValetModeRequest
{
    [JsonPropertyName("on")]
    public bool On { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}
