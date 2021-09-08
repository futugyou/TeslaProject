using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeslaApi.Authentication.Abstractions;
using TeslaApi.Contract;
using TeslaApi.Contract.Authentication;

namespace TeslaApi.Authentication
{
    public class TeslaAuthentication : ITeslaAuthentication
    {
        private readonly ILogger<TeslaAuthentication> _logger;
        private readonly AuthenticationOptions _options;
        private readonly HttpClient httpClient;

        public TeslaAuthentication(ILogger<TeslaAuthentication> logger,
            IOptionsMonitor<AuthenticationOptions> options,
            IHttpClientFactory clientFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            options = options ?? throw new ArgumentNullException(nameof(options));
            clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

            _options = options.CurrentValue;
            httpClient = clientFactory.CreateClient(TeslaApiConst.TESLA_HTTPCLIENT_NAME);
        }

        public async Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request, string bearerToken)
        {
            return await httpClient.UtilsPostAsync<AccessTokenRequest, AccessTokenResponse>(request, _options.AccessTokenEndPoint, bearerToken);
        }

        public Task<string> GetAuthorizeEndPoint(AuthorizeEndPointRequest request)
        {
            return Task.FromResult(_options.AuthCodeEndPoint + "?" + request.ConverToUri());
        }

        public async Task<BearerTokenResponse> GetBearerToken(BearerTokenRequest request)
        {
            return await httpClient.UtilsPostAsync<BearerTokenRequest, BearerTokenResponse>(request, _options.BearerTokenEndPoint);
        }
    }
}
