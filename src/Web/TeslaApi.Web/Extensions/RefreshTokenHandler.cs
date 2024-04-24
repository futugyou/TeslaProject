using TeslaApi.Contract;
using System.Net.Http.Headers;
using Polly;

namespace Extensions;

public class RefreshTokenHandler : DelegatingHandler
{
    private readonly ILogger<RefreshTokenHandler> _logger;
    public RefreshTokenHandler(ILogger<RefreshTokenHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // It will not be null because policy is added before handler
        var context = request.GetPolicyExecutionContext();

        // TODO: this is not ready
        if (request.Headers.Authorization == null)
        {
            // var vin = request.Headers.GetValues("x-tesla-api-vin").ToString();
            // var userid = request.Headers.GetValues("x-tesla-api-userid").ToString();
            // var vehilceid = request.Headers.Contains("x-tesla-api-vehicleid").ToString();
            // TeslaUserAuthInfo info = default;
            // if (!string.IsNullOrEmpty(vin))
            // {
            //     info = await _authInfoRepository.GetTeslaUserAuthInfoByVin(vin);
            // }
            // else if (!string.IsNullOrEmpty(userid))
            // {
            //     info = await _authInfoRepository.GetTeslaUserAuthInfoByUserId(userid);
            // }
            // else if (!string.IsNullOrEmpty(vehilceid))
            // {
            //     info = await _authInfoRepository.GetTeslaUserAuthInfoByVehicleId(vehilceid);
            // }
            // if (info == null || string.IsNullOrEmpty(info.AccessToken))
            // {
            //     throw new ArgumentNullException(nameof(request.Headers));
            // }
            // request.Headers.Authorization = new AuthenticationHeaderValue(TeslaApiConst.TESLA_Authorization_Type, info.AccessToken);
        }

        if (context != null && context.Count == 1)
        {
            if (context.TryGetValue(PolicyExtensions.TeslaTokenPolicy, out object token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(TeslaApiConst.TESLA_Authorization_Type, token as string);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}