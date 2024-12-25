using TeslaApi.Contract.Vehicle.State.ChargeState;
using TeslaApi.Contract.Vehicle.State.ClimateState;
using TeslaApi.Contract.Vehicle.State.DriveState;
using TeslaApi.Contract.Vehicle.State.GUISettings;
using TeslaApi.Contract.Vehicle.State.VehicleConfig;
using TeslaApi.Contract.Vehicle.State.VehicleState;

namespace TeslaApi.Contract.Vehicle.State.Data;

public class VehicleDataDetail
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    [JsonPropertyName("vehicle_id")]
    public long VehicleId { get; set; }
    [JsonPropertyName("vin")]
    public string Vin { get; set; }
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }
    [JsonPropertyName("option_codes")]
    public string OptionCodes { get; set; }
    [JsonPropertyName("color")]
    public object Color { get; set; }
    [JsonPropertyName("access_type")]
    public string AccessType { get; set; }
    [JsonPropertyName("tokens")]
    public string[] Tokens { get; set; }
    [JsonPropertyName("state")]
    public string State { get; set; }
    [JsonPropertyName("in_service")]
    public bool InService { get; set; }
    [JsonPropertyName("id_s")]
    public string IdS { get; set; }
    [JsonPropertyName("calendar_enabled")]
    public bool CalendarEnabled { get; set; }
    [JsonPropertyName("api_version")]
    public int? ApiVersion { get; set; }
    [JsonPropertyName("backseat_token")]
    public object BackseatToken { get; set; }
    [JsonPropertyName("backseat_token_updated_at")]
    public object BackseatTokenUpdatedAt { get; set; }
    [JsonPropertyName("drive_state")]
    public DriveStateDetail DriveState { get; set; }
    [JsonPropertyName("climate_state")]
    public ClimateStateDetail ClimateState { get; set; }
    [JsonPropertyName("charge_state")]
    public ChargeStateDetail ChargeState { get; set; }
    [JsonPropertyName("gui_settings")]
    public GuiSettingsDetail GuiSettings { get; set; }
    [JsonPropertyName("vehicle_state")]
    public VehicleStateDetail VehicleState { get; set; }
    [JsonPropertyName("vehicle_config")]
    public VehicleConfigDetail VehicleConfig { get; set; }
}