namespace TeslaApi.SDK;

public interface IVehicleState : IVehicleRefit
{
    [Get("/api/1/vehicles")]
    Task<VehiclesResponse> GetUserVehicles([Authorize("Bearer")] string token);

    [Get("/api/1/vehicles/{id}")]
    Task<VehicleResponse> GetUserVehicleById(string id, [Authorize("Bearer")] string token);

    [Get("/api/1/products")]
    Task<ProductsResponse> GetProductList([Authorize("Bearer")] string token);

    [Get("/api/1/vehicles/{id}/data")]
    Task<VehicleDataLegacyResponse> GetVehicleDataLegacy(string id, [Authorize("Bearer")] string token);

    [Get("/api/1/vehicles/{id}/vehicle_data")]
    Task<VehicleStateDataResponse> GetVehicleData(string id, [Authorize("Bearer")] string token);

    [Get("/api/1/vehicles/{id}/mobile_enabled")]
    Task<MobileEnabledResponse> GetVehicleMobileEnabled(string id, [Authorize("Bearer")] string token);

    [Get("/api/1/vehicles/{id}/nearby_charging_sites")]
    Task<NearbyChargingSitesResponse> GetNearbyChargingSites(string id, [Authorize("Bearer")] string token);
}
