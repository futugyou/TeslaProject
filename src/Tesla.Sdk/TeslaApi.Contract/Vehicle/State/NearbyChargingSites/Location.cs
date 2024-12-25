
namespace TeslaApi.Contract.Vehicle.State.NearbyChargingSites;

public class Location
{
    [JsonPropertyName("lat")]
    public float Lat { get; set; }
    [JsonPropertyName("long")]
    public float Long { get; set; }
}
