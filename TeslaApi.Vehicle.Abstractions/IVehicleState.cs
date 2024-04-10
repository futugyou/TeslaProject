
using TeslaApi.Contract.Vehicle.Products;
using TeslaApi.Contract.Vehicle.State.Data;
using TeslaApi.Contract.Vehicle.State.MobileEnabled;
using TeslaApi.Contract.Vehicle.State.NearbyChargingSites;
using TeslaApi.Contract.Vehicle.Vehicles;

namespace TeslaApi.Vehicle.Abstractions;

public interface IVehicleState
{
    Task<VehiclesResponse> GetUserVehicles(string token);
    Task<VehicleResponse> GetUserVehicleById(string id, string token);
    Task<ProductsResponse> GetProductList(string token);
    Task<VehicleDataLegacyResponse> GetVehicleDataLegacy(string id, string token);
    Task<VehicleStateDataResponse> GetVehicleData(string id, string token);
    Task<MobileEnabledResponse> GetVehicleMobileEnabled(string id, string token);
    Task<NearbyChargingSitesResponse> GetNearbyChargingSites(string id, string token);
}
