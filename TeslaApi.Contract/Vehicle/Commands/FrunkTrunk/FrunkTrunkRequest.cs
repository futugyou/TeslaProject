using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.Commands.FrunkTrunk
{
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
}
