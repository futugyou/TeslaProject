using Polly;
using System.Net;

namespace TeslaApi.Extensions.DependencyInjection;

public class PolicyExtensions
{
    public const string TeslaTokenPolicy = nameof(TeslaTokenPolicy);
    public static IAsyncPolicy<HttpResponseMessage> GetTokenRefresher(IServiceProvider provider, HttpRequestMessage request)
    {
        return Policy<HttpResponseMessage>
            .HandleResult(response => response.StatusCode == HttpStatusCode.Unauthorized)
            .RetryAsync(async (_, count) =>
            {
                var token = "get token from server";
                // var repo = await provider.GetRequiredService<ITeslaUserAuthInfoRepository>();

                var context = new Context
                {
                    { TeslaTokenPolicy,token }
                };
                request.SetPolicyExecutionContext(context);
            });
    }
}