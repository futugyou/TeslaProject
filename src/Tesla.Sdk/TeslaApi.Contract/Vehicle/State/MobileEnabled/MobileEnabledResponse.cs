
namespace TeslaApi.Contract.Vehicle.State.MobileEnabled;

public class MobileEnabledResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public bool Response { get; set; }
}
