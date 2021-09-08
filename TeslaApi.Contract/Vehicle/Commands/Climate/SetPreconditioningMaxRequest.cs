using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands.Climate
{
   public class SetPreconditioningMaxRequest
    {
        /// <summary>
        /// True to turn on, false to turn off.
        /// </summary>
        [JsonPropertyName("on")]
        public bool On { get; set; }
    }
}
