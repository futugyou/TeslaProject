using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class BluetoothKeysRequest
{
    [JsonPropertyName("kind")]
    public string Kind { get; } = "mobile_device";
    [JsonPropertyName("public_key")]
    public string PublicKey { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("model")]
    public string Model { get; set; }
}

public class BluetoothKeysResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public bool Response { get; set; }
}
