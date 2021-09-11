using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.User
{
    public class RoadsideAssistanceDataResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public RoadsideAssistanceDataDetail Response { get; set; }
    }

    public class RoadsideAssistanceDataDetail
    {
        [JsonPropertyName("enabled_vins")]
        public List<EnabledVins> EnabledVins { get; set; }
    }
}
