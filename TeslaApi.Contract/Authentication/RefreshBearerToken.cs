using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Authentication;

public class RefreshBearerTokenRequest
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

public class RefreshBearerTokenResponse : ResponseBase
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = "";
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = "";
    [JsonPropertyName("id_token")]
    public string IdToken { get; set; } = "";
    [JsonPropertyName("expires_in")]
    public int? ExpiresIn { get; set; }
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = "";
}
