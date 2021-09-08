using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.ChargeState
{
    public class ChargeStateResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public ChargeStateDetail Response { get; set; }
    }
}
