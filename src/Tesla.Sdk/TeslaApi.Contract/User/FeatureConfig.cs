namespace TeslaApi.Contract.User;

public class AuthRejection
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    [JsonPropertyName("min_version")]
    public int MinVersion { get; set; }
}

public class BleRoutable
{
    [JsonPropertyName("commands_enabled")]
    public bool CommandsEnabled { get; set; }

    [JsonPropertyName("state_enabled")]
    public bool StateEnabled { get; set; }
}

public class Response
{
    [JsonPropertyName("signaling")]
    public Signaling Signaling { get; set; }

    [JsonPropertyName("ble_routable")]
    public BleRoutable BleRoutable { get; set; }

    [JsonPropertyName("auth_rejection")]
    public AuthRejection AuthRejection { get; set; }
}

public class Signaling
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    [JsonPropertyName("subscribe_connectivity")]
    public bool SubscribeConnectivity { get; set; }

    [JsonPropertyName("use_auth_token")]
    public bool UseAuthToken { get; set; }
}


public class FeatureConfigResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public Response Response { get; set; }
}
