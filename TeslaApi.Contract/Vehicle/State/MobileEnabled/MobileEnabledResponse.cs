using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.State.MobileEnabled
{
    public class MobileEnabledResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public bool Response { get; set; }
    }
}
