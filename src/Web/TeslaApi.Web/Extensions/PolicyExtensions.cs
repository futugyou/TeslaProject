using Domain;
using Polly;
using System.Net;
using TeslaApi.Abstractions;
using TeslaApi.Contract.Authentication;

namespace Extensions;

public class PolicyExtensions
{
    public const string TeslaTokenPolicy = nameof(TeslaTokenPolicy);
    public static IAsyncPolicy<HttpResponseMessage> GetTokenRefresher(IServiceProvider provider, HttpRequestMessage request)
    {
        return Policy<HttpResponseMessage>
            .HandleResult(response => response.StatusCode == HttpStatusCode.Unauthorized)
            .RetryAsync(async (_, count) =>
            {
                var accessToken = request.Headers.Authorization?.Parameter;
                if (!string.IsNullOrWhiteSpace(accessToken))
                {
                    var repo = provider.GetRequiredService<ITokenRepository>();
                    var token = await repo.GetByAccessToken(accessToken);
                    if (token == null)
                    {
                        return;
                    }

                    var auth = provider.GetRequiredService<ITeslaAuthentication>();
                    var refreshTokenRequest = new RefreshTokenRequest { RefreshToken = token.RefreshToken };
                    var refresh = await auth.RefreshBearerToken(refreshTokenRequest);
                    if (refresh == null)
                    {
                        return;
                    }

                    accessToken = refresh.AccessToken;
                    token.AccessToken = accessToken;
                    token.ExpiresIn = refresh.ExpiresIn ?? 0;
                    token.RefreshToken = refresh.RefreshToken;
                    await repo.Update(token);
                }

                var context = new Context
                {
                    { TeslaTokenPolicy,accessToken }
                };
                request.SetPolicyExecutionContext(context);
            });
    }
}