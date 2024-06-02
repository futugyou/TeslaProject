using Refit;
using TeslaApi.Contract.Authentication;

namespace TeslaApi.SDK;

public interface ITeslaAuthentication
{
    Task<string> GetAuthorizeEndPoint(AuthorizeEndPointRequest request)
    {
        return Task.FromResult("https://auth.tesla.com/oauth2/v3/authorize?" + request.ConverToUri());
    }

    [Post("/oauth2/v3/token")]
    Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request);
    [Post("/oauth2/v3/token")]
    Task<AccessTokenResponse> RefreshBearerToken(RefreshTokenRequest request);
}
