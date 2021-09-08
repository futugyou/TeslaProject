using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands.Media
{
    public class MediaValue
    {
        [JsonPropertyName("android.intent.extra.TEXT")]
        public string AndroidIntentExtraTEXT { get; set; }
    }

    public class MediaRequest
    {
        /// <summary>
        /// Must be share_ext_content_raw.
        /// </summary>        
        [JsonPropertyName("type")]
        public string MediaType { get; } = "share_ext_content_raw";
        /// <summary>
        /// The address or video URL to set as the navigation destination.
        /// </summary>
        [JsonPropertyName("value")]
        public MediaValue MediaValue { get; set; }
        /// <summary>
        /// The locale for the navigation request. ISO 639-1 standard language codes
        /// </summary>        
        [JsonPropertyName("locale")]
        public string Locale { get; set; } = "zh-cn";
        /// <summary>
        /// The current UNIX timestamp.
        /// </summary>        
        [JsonPropertyName("timestamp_ms")]
        public long Timestamp { get; set; }

    }
}
