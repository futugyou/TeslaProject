using Refit;
using TeslaApi.Contract.User;

namespace TeslaApi.Abstractions;

public interface IUser
{
    [Get("/api/1/users/me")]
    Task<MeReponse> UserInformation([Authorize("Bearer")] string token);

    [Get("/api/1/users/vault_profile")]
    Task<VaultProfileResponse> VaultProfile([Authorize("Bearer")] string token);

    [Get("/api/1/users/feature_config")]
    Task<FeatureConfigResponse> FeatureConfig([Authorize("Bearer")] string token);

    [Post("/api/1/users/keys")]
    Task<BluetoothKeysResponse> BluetoothKeys(BluetoothKeysRequest request, [Authorize("Bearer")] string token);
}
