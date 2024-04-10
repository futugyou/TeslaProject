
using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.Climate;
public class SetCopTempRequest
{
    [JsonPropertyName("temp")]
    public int Temp { get; set; } 
}