using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class ServiceSelfSchedulingEligibilityResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public ServiceSelfSchedulingEligibilityDetail Response { get; set; }
}

public class ServiceSelfSchedulingEligibilityDetail
{
    [JsonPropertyName("enabled_vins")]
    public List<EnabledVins> EnabledVins { get; set; }
}
