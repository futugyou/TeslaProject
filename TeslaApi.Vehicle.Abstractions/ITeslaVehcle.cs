
using TeslaApi.Contract.Vehicle.Products;
using TeslaApi.Contract.Vehicle.Vehicles;

namespace TeslaApi.Vehicle.Abstractions;
public interface ITeslaVehcle
{
    Task<VehiclesResponse> GetUserVehicles(string token);
    Task<VehicleResponse> GetUserVehicleById(string id, string token);
    Task<ProductsResponse> GetProductList(string token);
    Task<VehicleDataLegacyResponse> GetVehicleDataLegacy(string id, string token);
}
