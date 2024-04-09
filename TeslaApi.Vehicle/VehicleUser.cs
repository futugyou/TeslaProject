using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeslaApi.Contract;
using TeslaApi.Contract.User;
using TeslaApi.Vehicle.Abstractions;

namespace TeslaApi.Vehicle;

public class VehicleUser : IVehicleUser
{
    private readonly ILogger<VehicleUser> _logger;
    private readonly VehicleOptions _options;
    private readonly HttpClient httpClient;

    public VehicleUser(
        ILogger<VehicleUser> logger,
        IOptionsMonitor<VehicleOptions> options,
        IHttpClientFactory clientFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        options = options ?? throw new ArgumentNullException(nameof(options));
        clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

        _options = options.CurrentValue;
        httpClient = clientFactory.CreateClient(TeslaApiConst.TESLA_SERVICE_HTTPCLIENT_NAME);
        httpClient.BaseAddress = new Uri(_options.TeslaBaseUrl);
    }
    public async Task<OnboardingExperienceResponse> GeOnboardingExperience(int id, string token)
    {
        var url = string.Format(_options.OnboardingExperience, id);
        return await httpClient.UtilsPostAsync<OnboardingExperienceResponse>(url, token);
    }

    public async Task<PowerwallOrderSessionDataResponse> GetPowerwallOrderSessionData(int id, string token)
    {
        var url = string.Format(_options.PowerwallOrderSessionData, id);
        return await httpClient.UtilsPostAsync<PowerwallOrderSessionDataResponse>(url, token);
    }

    public async Task<ReferralDataResponse> GetReferralData(int id, string token)
    {
        var url = string.Format(_options.ReferralData, id);
        return await httpClient.UtilsPostAsync<ReferralDataResponse>(url, token);
    }

    public async Task<RoadsideAssistanceDataResponse> GetRoadsideAssistanceData(int id, string token)
    {
        var url = string.Format(_options.RoadsideAssistanceData, id);
        return await httpClient.UtilsPostAsync<RoadsideAssistanceDataResponse>(url, token);
    }

    public async Task<ServiceSelfSchedulingEligibilityResponse> GetServiceSelfSchedulingEligibility(int id, string token)
    {
        var url = string.Format(_options.ServiceSelfSchedulingEligibility, id);
        return await httpClient.UtilsPostAsync<ServiceSelfSchedulingEligibilityResponse>(url, token);
    }
}
