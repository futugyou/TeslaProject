using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class RoadsideAssistanceDataResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public RoadsideAssistanceDataDetail Response { get; set; }
}

public class RoadsideAssistanceDataDetail
{
    [JsonPropertyName("enabled_vins")]
    public List<EnabledVins> EnabledVins { get; set; }
}
