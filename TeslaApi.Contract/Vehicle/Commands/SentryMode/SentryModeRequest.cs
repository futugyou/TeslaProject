using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.SentryMode;

public  class SentryModeRequest
{
    [JsonPropertyName("on")]
    public bool On { get; set; }
}
