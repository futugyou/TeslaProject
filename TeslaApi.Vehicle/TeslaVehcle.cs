
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeslaApi.Contract;
using TeslaApi.Contract.Vehicle.Products;
using TeslaApi.Contract.Vehicle.Vehicles;
using TeslaApi.Vehicle.Abstractions;

namespace TeslaApi.Vehicle;
public class TeslaVehcle : ITeslaVehcle
{
    private readonly ILogger<TeslaVehcle> _logger;
    private readonly VehicleOptions _options;
    private readonly HttpClient httpClient;

    public TeslaVehcle(ILogger<TeslaVehcle> logger,
        IOptionsMonitor<VehicleOptions> options,
        IHttpClientFactory clientFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        options = options ?? throw new ArgumentNullException(nameof(options));
        clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

        _options = options.CurrentValue;
        httpClient = clientFactory.CreateClient(TeslaApiConst.TESLA_HTTPCLIENT_NAME);
        httpClient.BaseAddress = new Uri(_options.TeslaBaseUrl);
    }

    public async Task<ProductsResponse> GetProductList(string token)
    {
        var url = _options.ProductList;
        return await httpClient.UtilsGetAsync<ProductsResponse>(url, token);
    }

    public async Task<VehicleResponse> GetUserVehicleById(string vehicle_id, string token)
    {
        var url = string.Format(_options.VehicleDetail, vehicle_id);
        return await httpClient.UtilsGetAsync<VehicleResponse>(url, token);
    }

    public async Task<VehiclesResponse> GetUserVehicles(string token)
    {
        var url = _options.VehicleList;
        return await httpClient.UtilsGetAsync<VehiclesResponse>(url, token);
    }

    public async Task<VehicleDataLegacyResponse> GetVehicleDataLegacy(string id, string token)
    {
        var url = string.Format(_options.VehicleDataLegacy, id);
        return await httpClient.UtilsGetAsync<VehicleDataLegacyResponse>(url, token);
    }
}
