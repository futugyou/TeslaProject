﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands.RemoteStart
{
    public class RemoteStartRequest
    {
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
