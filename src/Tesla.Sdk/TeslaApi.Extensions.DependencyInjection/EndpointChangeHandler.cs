using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeslaApi.Abstractions;
using TeslaApi.Contract;

namespace TeslaApi.Extensions.DependencyInjection;

public class EndpointChangeHandler(ILogger<EndpointChangeHandler> logger, IOptionsMonitor<TeslaOptions> options) : DelegatingHandler
{
    private readonly ILogger<EndpointChangeHandler> _logger = logger;
    private readonly TeslaOptions _options = options.CurrentValue;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization != null && !string.IsNullOrWhiteSpace(request.Headers.Authorization.Parameter) && request.RequestUri != null)
        {
            string token = request.Headers.Authorization.Parameter;
            var tokenInfo = new TokenInfo(token);
            if (tokenInfo.IsTokenExpiration())
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "token is expirated" };
            }

            if (tokenInfo.Locale == TokenLocal.China)
            {
                var uri = request.RequestUri.AbsoluteUri.Replace(_options.TeslaBaseUrl, _options.TeslaCnBaseUrl);
                request.RequestUri = new Uri(uri);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}