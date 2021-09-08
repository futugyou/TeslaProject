namespace TeslaApi.Authentication.Abstractions;
public class AuthenticationOptions
{
    public string AuthCodeEndPoint { get; set; } = "https://auth.tesla.com/oauth2/v3/authorize";
    public string BearerTokenEndPoint { get; set; } = "https://auth.tesla.cn/oauth2/v3/token";
    public string AccessTokenEndPoint { get; set; } = "https://owner-api.teslamotors.com/oauth/token";
    public string AuthClientId { get; set; } = "ownerapi";
    public string AuthRedirectUri { get; set; } = "https://auth.tesla.com/void/callback";
    public string AuthResponseType { get; set; } = "code";
    public string AuthScope { get; set; } = "openid email offline_access";
    public string GrantType { get; set; } = "urn:ietf:params:oauth:grant-type:jwt-bearer";
    public string ClientId { get; set; } = "81527cff06843c8634fdc09e8ac0abefb46ac849f38fe1e431c2ef2106796384";
    public string clientSecret { get; set; } = "c7257eb71a564034f9419ee651c7d0e5f7aa6bfbd18bafb5c5c033b093bb2fa3";
}
