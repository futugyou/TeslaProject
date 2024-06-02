using Microsoft.Extensions.Options;
using TeslaApi.Contract;
using TeslaApi.Contract.Vehicle.Miscellaneous;
using TeslaApi.Abstractions;

namespace TeslaApi;

public class VehicleMiscellaneous : IVehicleMiscellaneous
{
    private readonly TeslaOptions _options;
    private readonly HttpClient httpClient;

    public VehicleMiscellaneous(
        IOptionsMonitor<TeslaOptions> options,
        IHttpClientFactory clientFactory)
    {
        options = options ?? throw new ArgumentNullException(nameof(options));
        clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

        _options = options.CurrentValue;
        httpClient = clientFactory.CreateClient(TeslaApiConst.TESLA_SERVICE_HTTPCLIENT_NAME);
    }

    public Task<ReleaseNotesResponse> ReleaseNote(string vehicle_id, string token)
    {
        var url = string.Format(_options.ReleaseNotes, vehicle_id);
        return httpClient.UtilsGetAsync<ReleaseNotesResponse>(url, token);
    }
}