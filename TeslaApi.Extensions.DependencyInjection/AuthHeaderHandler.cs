using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeslaApi.Vehicle;
using TeslaApi.Vehicle.Abstractions;
using TeslaApi.Authentication;
using TeslaApi.Authentication.Abstractions;
using TeslaApi.Contract;
using Microsoft.Extensions.Logging;

namespace TeslaApi.Extensions.DependencyInjection;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly ILogger<AuthHeaderHandler> _logger;

    private const string RequestSourceHeaderName = "Request-Source";
    private const string RequestSource = "HttpClientFactorySampleApp";
    private const string RequestIdHeaderName = "Request-Identifier";

    public AuthHeaderHandler(ILogger<AuthHeaderHandler> logger)
    {
        _logger = logger;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization == null)
        {

        }
        request.Headers.Add(RequestSourceHeaderName, RequestSource); 

        return base.SendAsync(request, cancellationToken);
    }
}