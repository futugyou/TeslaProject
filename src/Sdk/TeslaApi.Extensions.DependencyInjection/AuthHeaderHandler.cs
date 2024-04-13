using Microsoft.Extensions.Logging;
using TeslaApi.Contract;
using TeslaApi.Storage.Abstractions;
using System.Net.Http.Headers;

namespace TeslaApi.Extensions.DependencyInjection;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly ILogger<AuthHeaderHandler> _logger;
    private readonly ITeslaUserAuthInfoRepository _authInfoRepository;
    public AuthHeaderHandler(ILogger<AuthHeaderHandler> logger, ITeslaUserAuthInfoRepository authInfoRepository)
    {
        _logger = logger;
        _authInfoRepository = authInfoRepository;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization == null)
        {
            var vin = request.Headers.GetValues("x-tesla-api-vin").ToString();
            var userid = request.Headers.GetValues("x-tesla-api-userid").ToString();
            var vehilceid = request.Headers.Contains("x-tesla-api-vehicleid").ToString();
            TeslaUserAuthInfo info = default;
            if (!string.IsNullOrEmpty(vin))
            {
                info = await _authInfoRepository.GetTeslaUserAuthInfoByVin(vin);
            }
            else if (!string.IsNullOrEmpty(userid))
            {
                info = await _authInfoRepository.GetTeslaUserAuthInfoByUserId(userid);
            }
            else if (!string.IsNullOrEmpty(vehilceid))
            {
                info = await _authInfoRepository.GetTeslaUserAuthInfoByVehicleId(vehilceid);
            }
            if (info == null || string.IsNullOrEmpty(info.AccessToken))
            {
                throw new ArgumentNullException(nameof(request.Headers));
            }
            request.Headers.Authorization = new AuthenticationHeaderValue(TeslaApiConst.TESLA_Authorization_Type, info.AccessToken);
        }
        return await base.SendAsync(request, cancellationToken);
    }
}