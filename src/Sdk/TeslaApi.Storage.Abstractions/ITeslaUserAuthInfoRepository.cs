namespace TeslaApi.Storage.Abstractions;

public interface ITeslaUserAuthInfoRepository
{
    Task SaveTeslaUserAuthInfo(TeslaUserAuthInfo info);
    Task<TeslaUserAuthInfo> GetTeslaUserAuthInfoByVin(string vin);
    Task<TeslaUserAuthInfo> GetTeslaUserAuthInfoByVehicleId(string vehicleId);
    Task<TeslaUserAuthInfo> GetTeslaUserAuthInfoByUserId(string userId);
}