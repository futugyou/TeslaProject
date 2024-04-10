using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class FeatureConfigReponse : ResponseBase
{
    [JsonPropertyName("signaling")]
    public Signaling Signaling { get; set; }
}

public class Signaling
{

    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }
    [JsonPropertyName("subscribe_connectivity")]
    public bool SubscribeConnectivity { get; set; }
}