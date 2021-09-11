using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.User
{
    public class PowerwallOrderSessionDataResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public PowerwallOrderSessionDataDetail Response { get; set; }
    }

    public class PowerwallOrderSessionDataDetail
    {
        [JsonPropertyName("feature_enabled")]
        public bool FeatureEnabled { get; set; }
    }
}
