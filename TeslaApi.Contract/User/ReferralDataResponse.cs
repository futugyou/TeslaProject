using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.User
{
    public class ReferralDataResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public ReferralDataDetail Response { get; set; }
    }

    public class ReferralDataDetail
    {
        [JsonPropertyName("feature_enabled")]
        public bool FeatureEnabled { get; set; }
    }
}
