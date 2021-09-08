using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TeslaApi.Contract
{
    public class TeslaApiConst
    {
        public static readonly string MEDIA_TYPE = "application/json";
        public static readonly string TESLA_HTTPCLIENT_NAME = "teslaapi";
        public static readonly string TESLA_Authorization_Type = "Bearer";
    }
}
