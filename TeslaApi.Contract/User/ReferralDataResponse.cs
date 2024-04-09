using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class ReferralDataResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public ReferralDataDetail Response { get; set; }
}

public class ReferralDataDetail
{
    [JsonPropertyName("feature_enabled")]
    public bool FeatureEnabled { get; set; }
}
