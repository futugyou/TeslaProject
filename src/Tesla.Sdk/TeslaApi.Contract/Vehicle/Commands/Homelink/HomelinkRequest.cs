
namespace TeslaApi.Contract.Vehicle.Commands.Homelink;

public  class HomelinkRequest
{
    [JsonPropertyName("lat")]
    public float Lat { get; set; }
    [JsonPropertyName("lon")]
    public float Lon { get; set; }
}
