using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class PowerwallOrderSessionDataResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public PowerwallOrderSessionDataDetail Response { get; set; }
}

public class PowerwallOrderSessionDataDetail
{
    [JsonPropertyName("feature_enabled")]
    public bool FeatureEnabled { get; set; }
}
