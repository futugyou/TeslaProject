using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TeslaApi.Vehicle;
using TeslaApi.Vehicle.Abstractions;
using TeslaApi.Authentication;
using TeslaApi.Authentication.Abstractions;
using TeslaApi.Contract;
using System.Net.Http.Headers;

namespace TeslaApi.Extensions.DependencyInjection;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly ILogger<AuthHeaderHandler> _logger;
    public AuthHeaderHandler(ILogger<AuthHeaderHandler> logger)
    {
        _logger = logger;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization == null)
        {
            var token = "";// TODO Get token
            request.Headers.Authorization = new AuthenticationHeaderValue(TeslaApiConst.TESLA_Authorization_Type, token);
        }
        return base.SendAsync(request, cancellationToken);
    }
}