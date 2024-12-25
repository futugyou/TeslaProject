namespace TeslaApi.Extensions.DependencyInjection;

public class EndpointChangeHandler(ILogger<EndpointChangeHandler> logger) : DelegatingHandler
{
    public string TeslaBaseUrl { get; set; } = "https://owner-api.teslamotors.com";
    public string TeslaCnBaseUrl { get; set; } = "https://owner-api.vn.cloud.tesla.cn";
    private readonly ILogger<EndpointChangeHandler> _logger = logger;

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
                var uri = request.RequestUri.AbsoluteUri.Replace(TeslaBaseUrl, TeslaCnBaseUrl);
                request.RequestUri = new Uri(uri);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}