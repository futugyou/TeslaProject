using TeslaApi.Storage.Abstractions;

namespace TeslaApi.Storage;

public class DefaultTeslaUserAuthInfoRepository : ITeslaUserAuthInfoRepository
{
    private readonly Dictionary<string, TeslaUserAuthInfo> VinDefaultDic = new Dictionary<string, TeslaUserAuthInfo>();
    private readonly Dictionary<string, TeslaUserAuthInfo> VehicleIdDefaultDic = new Dictionary<string, TeslaUserAuthInfo>();
    private readonly Dictionary<string, TeslaUserAuthInfo> UserIdDefaultDic = new Dictionary<string, TeslaUserAuthInfo>();

    public DefaultTeslaUserAuthInfoRepository()
    {

    }

    public async Task SaveTeslaUserAuthInfo(TeslaUserAuthInfo info)
    {
        if (!VinDefaultDic.ContainsKey(info.Vin))
        {
            VinDefaultDic.Add(info.Vin, info);
        }
        else
        {
            VinDefaultDic[info.Vin] = info;
        }

        if (!VehicleIdDefaultDic.ContainsKey(info.VehicleId))
        {
            VehicleIdDefaultDic.Add(info.VehicleId, info);
        }
        else
        {
            VehicleIdDefaultDic[info.VehicleId] = info;
        }

        if (!UserIdDefaultDic.ContainsKey(info.UserId))
        {
            UserIdDefaultDic.Add(info.UserId, info);
        }
        else
        {
            UserIdDefaultDic[info.UserId] = info;
        }
        await Task.CompletedTask;
    }

    public async Task<TeslaUserAuthInfo> GetTeslaUserAuthInfoByVin(string vin)
    {
        if (!VinDefaultDic.ContainsKey(vin))
        {
            return VinDefaultDic[vin];
        }
        return await Task.FromResult<TeslaUserAuthInfo>(new TeslaUserAuthInfo());
    }

    public async Task<TeslaUserAuthInfo> GetTeslaUserAuthInfoByVehicleId(string vehicleId)
    {
        if (!VehicleIdDefaultDic.ContainsKey(vehicleId))
        {
            return VehicleIdDefaultDic[vehicleId];
        }
        return await Task.FromResult<TeslaUserAuthInfo>(new TeslaUserAuthInfo());
    }

    public async Task<TeslaUserAuthInfo> GetTeslaUserAuthInfoByUserId(string userId)
    {
        if (!UserIdDefaultDic.ContainsKey(userId))
        {
            return UserIdDefaultDic[userId];
        }
        return await Task.FromResult<TeslaUserAuthInfo>(new TeslaUserAuthInfo());
    }
}
