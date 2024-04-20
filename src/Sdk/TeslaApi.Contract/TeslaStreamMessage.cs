using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TeslaApi.Contract;

public class TeslaStreamMessage
{
    [JsonPropertyName("msg_type")]
    public MessageType MsgType { get; set; }
    [JsonPropertyName("tag")]
    public string Tag { get; set; }
    [JsonPropertyName("token")]
    public string Token { get; set; }
    [JsonPropertyName("connection_timeout")]
    public long ConnectionTimeout { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
    [JsonPropertyName("error_type")]
    public string ErrorType { get; set; }//client_error vehicle_disconnected vehicle_error
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}

public enum MessageType
{
    [Description("data:subscribe")]  // not support 
    Subscribe,
    [Description("data:unsubscribe")]
    Unsubscribe,
    [Description("data:update")]
    Update,
    [Description("data:error")]
    WsError,
    [Description("control:hello")]
    Hello,
    [Description("data:subscribe_oauth")]
    SubscribeOauth,
    [Description("control:ping")]
    Ping,
    [Description("autopark:info")]
    Info,
    [Description("autopark:device_location")]
    DeviceLocation,
    [Description("autopark:cmd_forward")]
    CmdForward,
    [Description("autopark:cmd_reverse")]
    CmdReverse,
    [Description("autopark:heartbeat_app")]
    HeartbeatApp,
    [Description("autopark:cmd_abort")]
    CmdAbort,
}

public class StreamRequest
{
    [JsonPropertyName("user_id")]
    public string UserID { get; set; }
    [JsonPropertyName("vin_id")]
    public long VinID { get; set; }
    [JsonPropertyName("vin")]
    public string Vin { get; set; }
    [JsonPropertyName("user_name")]
    public string UserName { get; set; }
    [JsonPropertyName("token")]
    public string Token { get; set; }
}
