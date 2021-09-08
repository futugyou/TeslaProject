﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands.Wake
{
    public class VehicleWakeResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public VehicleWakeDetail Response { get; set; }
    }
}