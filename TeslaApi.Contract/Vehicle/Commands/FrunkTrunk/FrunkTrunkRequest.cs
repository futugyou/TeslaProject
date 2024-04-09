using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.Commands.FrunkTrunk;

public class FrunkTrunkRequest
{
    [JsonPropertyName("which_trunk")]
    public FrunkTrunkType WhichTrunk { get; set; }
}
public enum FrunkTrunkType
{
    [EnumMember(Value = "front")]
    Front,
    [EnumMember(Value = "rear")]
    Rear,
}
