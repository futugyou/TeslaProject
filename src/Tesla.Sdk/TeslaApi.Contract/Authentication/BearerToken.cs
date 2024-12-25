namespace TeslaApi.Contract.Authentication;

public class BearerTokenRequest
{
    [JsonPropertyName("grant_type")]
    public string GrantType { get; set; } = "authorization_code";
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; } = "ownerapi";
    [JsonPropertyName("redirect_uri")]
    public string RedirectUri { get; set; } = "https://auth.tesla.com/void/callback";
    [JsonPropertyName("code_verifier")]
    public string CodeVerifier { get; set; }
    [JsonPropertyName("code")]
    public string Code { get; set; }
}

public class BearerTokenResponse : ResponseBase
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = "";
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = "";
    [JsonPropertyName("id_token")]
    public string IdToken { get; set; } = "";
    [JsonPropertyName("expires_in")]
    public int? ExpiresIn { get; set; }
    [JsonPropertyName("state")]
    public string State { get; set; } = "";
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = "";
}
