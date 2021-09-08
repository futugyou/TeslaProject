using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.State.VehicleState
{
    public class VehicleStateResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public VehicleStateDetail Response { get; set; }
    }
}
