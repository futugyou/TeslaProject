using TeslaApi.Contract.User;

namespace TeslaApi.User.Abstractions;

public interface IUser
{
    Task<MeReponse> UserInformation(string token);
    Task<VaultProfileResponse> VaultProfile(string token);
    Task<FeatureConfigResponse> FeatureConfig(string token);
    Task<BluetoothKeysResponse> BluetoothKeys(BluetoothKeysRequest request,string token);
}
