namespace TeslaApi.User.Abstractions;

public class UserOptions
{
    public string Me { get; set; } = "/api/1/users/me";
    public string VaultProfile { get; set; } = "/api/1/users/vault_profile";
    public string FeatureConfig { get; set; } = "/api/1/users/feature_config";
    public string UserKeys { get; set; } = "/api/1/users/keys";

}
