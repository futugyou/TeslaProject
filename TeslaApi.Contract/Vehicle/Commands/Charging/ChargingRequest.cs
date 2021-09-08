﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands.Charging
{
    public class ChargingRequest
    {
        [JsonPropertyName("percent")]
        public int? Percent { get; set; }
    }
}
