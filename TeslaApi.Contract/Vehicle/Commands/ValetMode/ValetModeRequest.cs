using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands.ValetMode
{
    public class ValetModeRequest
    {
        [JsonPropertyName("on")]
        public bool On { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
