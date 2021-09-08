using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.VehicleState
{
    public class MediaState
    {
        [JsonPropertyName("remote_control_enabled")]
        public bool RemoteControlEnabled { get; set; }
    }

}