using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Vehicles
{
    public class VehicleResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public VehicleDetail Response { get; set; }
    }
}
