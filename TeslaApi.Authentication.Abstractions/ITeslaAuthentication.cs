using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaApi.Contract.Authentication;

namespace TeslaApi.Authentication.Abstractions
{
    public interface ITeslaAuthentication
    {
        Task<string> GetAuthorizeEndPoint(AuthorizeEndPointRequest request);
        Task<BearerTokenResponse> GetBearerToken(BearerTokenRequest request);
        Task<RefreshBearerTokenResponse> RefreshBearerToken(RefreshBearerTokenRequest request);
        Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request, string bearerToken);
    }
}
