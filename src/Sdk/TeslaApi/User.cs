using Microsoft.Extensions.Options;
using TeslaApi.Contract;
using TeslaApi.Contract.User;
using TeslaApi.Abstractions;

namespace TeslaApi;

public class User : IUser
{
    private readonly TeslaOptions _options;
    private readonly HttpClient httpClient;

    public User(IOptionsMonitor<TeslaOptions> options,
        IHttpClientFactory clientFactory)
    {
        options = options ?? throw new ArgumentNullException(nameof(options));
        clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

        _options = options.CurrentValue;
        httpClient = clientFactory.CreateClient(TeslaApiConst.TESLA_SERVICE_HTTPCLIENT_NAME);
    }

    public Task<BluetoothKeysResponse> BluetoothKeys(BluetoothKeysRequest request, string token)
    {
        return httpClient.UtilsPostAsync<BluetoothKeysRequest, BluetoothKeysResponse>(request, _options.UserKeys, token);
    }

    public Task<FeatureConfigResponse> FeatureConfig(string token)
    {
        return httpClient.UtilsGetAsync<FeatureConfigResponse>(_options.FeatureConfig, token);
    }

    public Task<MeReponse> UserInformation(string token)
    {
        return httpClient.UtilsGetAsync<MeReponse>(_options.Me, token);
    }

    public Task<VaultProfileResponse> VaultProfile(string token)
    {
        return httpClient.UtilsGetAsync<VaultProfileResponse>(_options.VaultProfile, token);
    }
}
