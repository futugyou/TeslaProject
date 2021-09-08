using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands.Windows
{
    public class WindowsRequest
    {
        [JsonPropertyName("command")]
        public CommandType Command { get; set; }
        [JsonPropertyName("lat")]
        public float Lat { get; set; }
        [JsonPropertyName("lon")]
        public float Lon { get; set; }
    }

    public enum CommandType
    {
        [EnumMember(Value = "vent")]
        Vent,
        [EnumMember(Value = "close")]
        Close,
    }
}
