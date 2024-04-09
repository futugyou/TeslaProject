using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.SoftwareUpdates;

public  class ScheduleSoftwareUpdateRequest
{
    /// <summary>
    /// How many seconds in the future to schedule the update. Set to 0 for immediate install.
    /// </summary>
    [JsonPropertyName("offset_sec")]
    public long OffsetSec { get; set; }
}
