using TeslaApi.Contract.Authentication;

namespace TeslaApi.Abstractions;

public interface ITeslaAuthentication
{
    Task<string> GetAuthorizeEndPoint(AuthorizeEndPointRequest request); 
    Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request);
    Task<AccessTokenResponse> RefreshBearerToken(RefreshTokenRequest request);
}
