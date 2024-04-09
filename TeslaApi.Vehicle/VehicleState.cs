
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeslaApi.Contract;
using TeslaApi.Contract.Vehicle.Products;
using TeslaApi.Contract.Vehicle.State.ChargeState;
using TeslaApi.Contract.Vehicle.State.ClimateState;
using TeslaApi.Contract.Vehicle.State.Data;
using TeslaApi.Contract.Vehicle.State.DriveState;
using TeslaApi.Contract.Vehicle.State.GUISettings;
using TeslaApi.Contract.Vehicle.State.MobileEnabled;
using TeslaApi.Contract.Vehicle.State.NearbyChargingSites;
using TeslaApi.Contract.Vehicle.State.VehicleConfig;
using TeslaApi.Contract.Vehicle.State.VehicleState;
using TeslaApi.Contract.Vehicle.Vehicles;
using TeslaApi.Vehicle.Abstractions;

namespace TeslaApi.Vehicle;

public class VehicleState : IVehicleState
{
    private readonly ILogger<VehicleState> _logger;
    private readonly VehicleOptions _options;
    private readonly HttpClient httpClient;

    public VehicleState(ILogger<VehicleState> logger,
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

    public async Task<ChargeStateResponse> GetVehicleChargeState(string id, string token)
    {
        var url = string.Format(_options.ChargeState, id);
        return await httpClient.UtilsGetAsync<ChargeStateResponse>(url, token);
    }

    public async Task<ClimateStateResponse> GetVehicleClimateState(string id, string token)
    {
        var url = string.Format(_options.ClimateState, id);
        return await httpClient.UtilsGetAsync<ClimateStateResponse>(url, token);
    }

    public async Task<VehicleStateDataResponse> GetVehicleData(string id, string token)
    {
        var url = string.Format(_options.VehicleData, id);
        return await httpClient.UtilsGetAsync<VehicleStateDataResponse>(url, token);
    }

    public async Task<VehicleDataLegacyResponse> GetVehicleDataLegacy(string id, string token)
    {
        var url = string.Format(_options.VehicleDataLegacy, id);
        return await httpClient.UtilsGetAsync<VehicleDataLegacyResponse>(url, token);
    }

    public async Task<DriveStateResponse> GetVehicleDriveState(string id, string token)
    {
        var url = string.Format(_options.DriveState, id);
        return await httpClient.UtilsGetAsync<DriveStateResponse>(url, token);
    }

    public async Task<GUISettingsResponse> GetVehicleGuiSettings(string id, string token)
    {
        var url = string.Format(_options.GuiSettings, id);
        return await httpClient.UtilsGetAsync<GUISettingsResponse>(url, token);
    }

    public async Task<VehicleStateResponse> GetVehicleState(string id, string token)
    {
        var url = string.Format(_options.VehicleState, id);
        return await httpClient.UtilsGetAsync<VehicleStateResponse>(url, token);
    }

    public async Task<VehicleConfigResponse> GetVehicleConfig(string id, string token)
    {
        var url = string.Format(_options.VehicleConfig, id);
        return await httpClient.UtilsGetAsync<VehicleConfigResponse>(url, token);
    }

    public async Task<MobileEnabledResponse> GetVehicleMobileEnabled(string id, string token)
    {
        var url = string.Format(_options.MobileEnabled, id);
        return await httpClient.UtilsGetAsync<MobileEnabledResponse>(url, token);
    }

    public async Task<NearbyChargingSitesResponse> GetNearbyChargingSites(string id, string token)
    {
        var url = string.Format(_options.NearbyChargingSites, id);
        return await httpClient.UtilsGetAsync<NearbyChargingSitesResponse>(url, token);
    }
}
