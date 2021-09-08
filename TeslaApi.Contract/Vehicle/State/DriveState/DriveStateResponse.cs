using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.State.DriveState
{
    public class DriveStateResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public DriveStateDetail Response { get; set; }
    }
}
