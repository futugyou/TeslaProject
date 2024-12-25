
namespace TeslaApi.Contract.Vehicle.State.VehicleState;

public class SoftwareUpdate
{
    [JsonPropertyName("download_perc")]
    public int? DownloadPerc { get; set; }
    [JsonPropertyName("expected_duration_sec")]
    public int? ExpectedDurationSec { get; set; }
    [JsonPropertyName("install_perc")]
    public int? InstallPerc { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
    [JsonPropertyName("version")]
    public string Version { get; set; }
}