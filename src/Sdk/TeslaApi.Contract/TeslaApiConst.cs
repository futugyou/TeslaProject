namespace TeslaApi.Contract;

public class TeslaApiConst
{
    public static readonly string TeslaMessageDataColumns = string.Join(",", ["speed", "odometer", "soc", "elevation", "est_heading", "est_lat",
    "est_lng", "est_corrected_lat", "est_corrected_lng", "native_latitude", "native_longitude", "native_heading", "native_type",
    "native_location_supported", "power", "shift_state","range","est_range","heading"]);

    public static readonly string MEDIA_TYPE = "application/json";
    public static readonly string TESLA_AUTH_HTTPCLIENT_NAME = "teslaapi";
    public static readonly string TESLA_SERVICE_HTTPCLIENT_NAME = "teslaapi";
    public static readonly string TESLA_Authorization_Type = "Bearer";
    public static readonly string TESLA_STREAM_URL = "wss://streaming.vn.teslamotors.com/streaming"; // TODO: wss://streaming.vn.cloud.tesla.cn/streaming/
   
}
