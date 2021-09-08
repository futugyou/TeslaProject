using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Sunroof
{
    public class SunroofRequest
    {
        [JsonPropertyName("state")]
        public SunroofType State { get; set; }
    }
    public enum SunroofType
    {
        [EnumMember(Value = "vent")]
        Vent,
        [EnumMember(Value = "close")]
        Close,
    }
}
