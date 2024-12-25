

namespace TeslaApi.Contract.Vehicle.Commands.Windows;

public class WindowsRequest
{
    [JsonPropertyName("command")]
    public CommandType Command { get; set; }
    [JsonPropertyName("lat")]
    public float Lat { get; set; }
    [JsonPropertyName("lon")]
    public float Lon { get; set; }
}

public enum CommandType
{
    [EnumMember(Value = "vent")]
    Vent,
    [EnumMember(Value = "close")]
    Close,
}
