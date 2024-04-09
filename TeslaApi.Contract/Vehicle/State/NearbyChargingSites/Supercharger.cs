using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.NearbyChargingSites;

public class Supercharger
{
    [JsonPropertyName("location")]
    public Location Location { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("distance_miles")]
    public float DistanceMiles { get; set; }
    [JsonPropertyName("available_stalls")]
    public int? AvailableStalls { get; set; }
    [JsonPropertyName("total_stalls")]
    public int? TotalStalls { get; set; }
    [JsonPropertyName("site_closed")]
    public bool SiteClosed { get; set; }
}
