using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class VaultProfile : ResponseBase
{
    [JsonPropertyName("vault")]
    public string Vault { get; set; }
}
