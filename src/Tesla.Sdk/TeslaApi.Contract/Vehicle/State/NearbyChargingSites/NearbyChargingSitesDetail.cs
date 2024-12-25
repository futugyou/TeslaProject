
namespace TeslaApi.Contract.Vehicle.State.NearbyChargingSites;

public class NearbyChargingSitesDetail
{
    [JsonPropertyName("congestion_sync_time_utc_secs")]
    public int? CongestionSyncTimeUtcSecs { get; set; }
    [JsonPropertyName("destination_charging")]
    public DestinationCharging[] DestinationCharging { get; set; }
    [JsonPropertyName("superchargers")]
    public Supercharger[] Superchargers { get; set; }
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}
