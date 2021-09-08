using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands.Homelink
{
  public  class HomelinkRequest
    {
        [JsonPropertyName("lat")]
        public float Lat { get; set; }
        [JsonPropertyName("lon")]
        public float Lon { get; set; }
    }
}
