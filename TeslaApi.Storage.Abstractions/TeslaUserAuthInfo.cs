namespace TeslaApi.Storage.Abstractions;

public class TeslaUserAuthInfo
{
    public string UserId { get; set; }
    public string VehicleId { get; set; }
    public string Vin { get; set; }
    public string DisplayName { get; set; }
    public string BearerToken { get; set; }
    public string RefreshBearerToken { get; set; }
    public int BearerExpiresIn { get; set; }
    public string AccessToken { get; set; }
    public string RefreshAccessToken { get; set; }
    public int AccessExpiresIn { get; set; }
}
