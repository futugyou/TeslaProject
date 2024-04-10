using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class VaultProfileResponse : ResponseBase
{
    [JsonPropertyName("vault")]
    public string Vault { get; set; }
}
