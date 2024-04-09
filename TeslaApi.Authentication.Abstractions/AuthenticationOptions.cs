namespace TeslaApi.Authentication.Abstractions;

public class AuthenticationOptions
{
    public string AuthCodeEndPoint { get; set; } = "https://auth.tesla.com/oauth2/v3/authorize";
    public string AccessTokenEndPoint { get; set; } = "https://auth.tesla.com/oauth2/v3/token";
    public string RefreshTokenEndPoint { get; set; } = "https://auth.tesla.com/oauth2/v3/token";
    public string AccessTokenEndPoint_CN { get; set; } = "https://auth.tesla.cn/oauth2/v3/token";
    public string RefreshTokenEndPoint_CN { get; set; } = "https://auth.tesla.cn/oauth2/v3/token"; 
    public string AuthClientId { get; set; } = "ownerapi";
    public string AuthRedirectUri { get; set; } = "https://auth.tesla.com/void/callback";
    public string AuthResponseType { get; set; } = "code";
    public string AuthScope { get; set; } = "openid email offline_access"; 
}
