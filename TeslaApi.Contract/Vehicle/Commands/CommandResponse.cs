using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands
{
    public class CommandResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public CommandDetaileResponse Response { get; set; }
    }
    public class CommandDetaileResponse
    {
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
        [JsonPropertyName("result")]
        public bool Result { get; set; }
    }
}
