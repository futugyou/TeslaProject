namespace TeslaApi.Contract.Authentication;

public class AccessTokenRequest
{
    [JsonPropertyName("grant_type")]
    public string GrantType { get; set; } = "authorization_code";

    [JsonPropertyName("client_id")]
    public string ClientId { get; set; } = "ownerapi";

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("code_verifier")]
    public string CodeVerifier { get; set; }

    [JsonPropertyName("redirect_uri")]
    public string RedirectUri { get; } = "https://auth.tesla.com/void/callback";
}

public class AccessTokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = "";
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = "";
    [JsonPropertyName("expires_in")]
    public int? ExpiresIn { get; set; }
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = "";
    [JsonPropertyName("state")]
    public string State { get; set; }
    [JsonPropertyName("id_token")]
    public string? IDToken { get; set; }
}
