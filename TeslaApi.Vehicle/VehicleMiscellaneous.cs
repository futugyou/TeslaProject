using Microsoft.Extensions.Options;
using TeslaApi.Contract;
using TeslaApi.Contract.Vehicle.Miscellaneous;
using TeslaApi.Vehicle.Abstractions;

namespace TeslaApi.Vehicle;

public class VehicleMiscellaneous : IVehicleMiscellaneous
{
    private readonly VehicleOptions _options;
    private readonly HttpClient httpClient;

    public VehicleMiscellaneous(
        IOptionsMonitor<VehicleOptions> options,
        IHttpClientFactory clientFactory)
    {
        options = options ?? throw new ArgumentNullException(nameof(options));
        clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

        _options = options.CurrentValue;
        httpClient = clientFactory.CreateClient(TeslaApiConst.TESLA_SERVICE_HTTPCLIENT_NAME);
        httpClient.BaseAddress = new Uri(_options.TeslaBaseUrl);
    }

    public Task<ReleaseNotesResponse> ReleaseNote(string vehicle_id, string token)
    {
        var url = string.Format(_options.ReleaseNotes, vehicle_id);
        return httpClient.UtilsGetAsync<ReleaseNotesResponse>(url, token);
    }
}