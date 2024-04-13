using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.NearbyChargingSites;

public class DestinationCharging
{
    [JsonPropertyName("location")]
    public Location Location { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("distance_miles")]
    public float DistanceMiles { get; set; }
}
