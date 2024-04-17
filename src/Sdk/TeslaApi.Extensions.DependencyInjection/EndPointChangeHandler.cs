using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeslaApi.Abstractions;
using TeslaApi.Contract;

namespace TeslaApi.Extensions.DependencyInjection;

public class EndPointChangeHandler(ILogger<EndPointChangeHandler> logger, IOptionsMonitor<TeslaOptions> options) : DelegatingHandler
{
    private readonly ILogger<EndPointChangeHandler> _logger = logger;
    private readonly TeslaOptions _options = options.CurrentValue;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization != null && !string.IsNullOrWhiteSpace(request.Headers.Authorization.Parameter) && request.RequestUri != null)
        {
            string token = request.Headers.Authorization.Parameter;
            var local = TokenParse.CheckTokenLocal(token);
            if (local == TokenLocal.China)
            {
                var uri = request.RequestUri.AbsoluteUri.Replace(_options.TeslaBaseUrl, _options.TeslaCnBaseUrl);
                request.RequestUri = new Uri(uri);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}