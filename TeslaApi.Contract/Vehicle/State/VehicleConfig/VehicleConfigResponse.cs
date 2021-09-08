using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.State.VehicleConfig
{
    public class VehicleConfigResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public VehicleConfigDetail Response { get; set; }
    }
}
