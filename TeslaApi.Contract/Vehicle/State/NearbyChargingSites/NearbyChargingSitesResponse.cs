using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.State.NearbyChargingSites
{
    public class NearbyChargingSitesResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public NearbyChargingSitesDetail Response { get; set; }
    }
}
