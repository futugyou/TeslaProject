using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.NearbyChargingSites;

public class NearbyChargingSitesResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public NearbyChargingSitesDetail Response { get; set; }
}
