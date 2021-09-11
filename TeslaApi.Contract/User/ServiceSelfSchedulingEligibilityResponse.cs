using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.User
{
    public class ServiceSelfSchedulingEligibilityResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public ServiceSelfSchedulingEligibilityDetail Response { get; set; }
    }

    public class ServiceSelfSchedulingEligibilityDetail
    {
        [JsonPropertyName("enabled_vins")]
        public List<EnabledVins> EnabledVins { get; set; }
    }
}
