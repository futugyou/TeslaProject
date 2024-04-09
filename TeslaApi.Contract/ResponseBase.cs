using System.Text.Json.Serialization;

namespace TeslaApi.Contract;

public class ResponseBase
{
    [JsonPropertyName("error")]
    public string error { get; set; } = "";
    [JsonPropertyName("error_description")]
    public string error_description { get; set; } = "";
    [JsonPropertyName("error_uri")]
    public string error_uri { get; set; } = "";
}
