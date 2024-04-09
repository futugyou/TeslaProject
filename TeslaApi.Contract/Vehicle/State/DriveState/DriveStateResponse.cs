using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.DriveState;

public class DriveStateResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public DriveStateDetail Response { get; set; }
}
