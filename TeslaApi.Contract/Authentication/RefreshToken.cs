using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Authentication;

public class RefreshTokenRequest
{
    [JsonPropertyName("grant_type")]
    public string GrantType { get; set; } = "refresh_token";
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; } = "ownerapi";
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
    [JsonPropertyName("scope")]
    public string Scope { get; } = "openid email offline_access";
}
