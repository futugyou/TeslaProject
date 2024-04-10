using Microsoft.Extensions.Options;
using TeslaApi.Authentication.Abstractions;
using TeslaApi.Contract;
using TeslaApi.Contract.Authentication;

namespace TeslaApi.Authentication;

public class TeslaAuthentication : ITeslaAuthentication
{
    private readonly AuthenticationOptions _options;
    private readonly HttpClient httpClient;

    public TeslaAuthentication(
        IOptionsMonitor<AuthenticationOptions> options,
        IHttpClientFactory clientFactory)
    {
        options = options ?? throw new ArgumentNullException(nameof(options));
        clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

        _options = options.CurrentValue;
        httpClient = clientFactory.CreateClient(TeslaApiConst.TESLA_AUTH_HTTPCLIENT_NAME);
    }

    public Task<string> GetAuthorizeEndPoint(AuthorizeEndPointRequest request)
    {
        return Task.FromResult(_options.AuthCodeEndPoint + "?" + request.ConverToUri());
    }

    public Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request)
    {
        return httpClient.UtilsPostAsync<AccessTokenRequest, AccessTokenResponse>(request, _options.AccessTokenEndPoint);
    }

    public Task<AccessTokenResponse> RefreshBearerToken(RefreshTokenRequest request)
    {
        return httpClient.UtilsPostAsync<RefreshTokenRequest, AccessTokenResponse>(request, _options.RefreshTokenEndPoint);
    }
}
