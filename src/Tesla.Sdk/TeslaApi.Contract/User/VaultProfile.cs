using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class VaultProfileResponse : ResponseBase<VaultProfileDetail>
{ 
}

public class VaultProfileDetail
{
    [JsonPropertyName("vault")]
    public string Vault { get; set; }
}