using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.VehicleState;

public class VehicleStateDetail
{
    [JsonPropertyName("api_version")]
    public int? ApiVersion { get; set; }
    [JsonPropertyName("autopark_state_v2")]
    public string AutoparkStateV2 { get; set; }
    [JsonPropertyName("autopark_style")]
    public string AutoparkStyle { get; set; }
    [JsonPropertyName("calendar_supported")]
    public bool? CalendarSupported { get; set; }
    [JsonPropertyName("car_version")]
    public string CarVersion { get; set; }     
    [JsonPropertyName("center_display_state")]
    public CenterDisplayState CenterDisplayState { get; set; }
    /// <summary>
    /// driver front
    /// </summary>
    [JsonPropertyName("df")]
    public int? Df { get; set; }
    /// <summary>
    /// driver rear
    /// </summary>
    [JsonPropertyName("dr")]
    public int? Dr { get; set; }
    [JsonPropertyName("fd_window")]
    public int? FdWindow { get; set; }
    [JsonPropertyName("fp_window")]
    public int? FpWindow { get; set; }
    [JsonPropertyName("homelink_device_count")]
    public int? HomelinkDeviceCount { get; set; }
    [JsonPropertyName("homelink_nearby")]
    public bool? HomelinkNearby { get; set; }
    [JsonPropertyName("is_user_present")]
    public bool? IsUserPresent { get; set; }
    [JsonPropertyName("last_autopark_error")]
    public string LastAutoparkError { get; set; }
    [JsonPropertyName("locked")]
    public bool? Locked { get; set; }
    [JsonPropertyName("media_state")]
    public MediaState MediaState { get; set; }
    [JsonPropertyName("notifications_supported")]
    public bool? NotificationsSupported { get; set; }
    [JsonPropertyName("odometer")]
    public float Odometer { get; set; }
    [JsonPropertyName("parsed_calendar_supported")]
    public bool? ParsedCalendarSupported { get; set; }
    /// <summary>
    /// passenger front
    /// </summary>
    [JsonPropertyName("pf")]
    public int? Pf { get; set; }
    /// <summary>
    /// passenger rear
    /// </summary>
    [JsonPropertyName("pr")]
    public int? Pr { get; set; }
    [JsonPropertyName("rd_window")]
    public int? RdWindow { get; set; }
    [JsonPropertyName("remote_start")]
    public bool? RemoteStart { get; set; }
    [JsonPropertyName("remote_start_enabled")]
    public bool? RemoteStartEnabled { get; set; }
    [JsonPropertyName("remote_start_supported")]
    public bool? RemoteStartSupported { get; set; }
    [JsonPropertyName("rp_window")]
    public int? RpWindow { get; set; }
    /// <summary>
    /// front trunk
    /// </summary>
    [JsonPropertyName("ft")]
    public int? Ft { get; set; }
    /// <summary>
    /// rear trunk
    /// </summary>
    [JsonPropertyName("rt")]
    public int? Rt { get; set; }
    [JsonPropertyName("sentry_mode")]
    public bool? SentryMode { get; set; }
    [JsonPropertyName("sentry_mode_available")]
    public bool? SentryModeAvailable { get; set; }
    [JsonPropertyName("smart_summon_available")]
    public bool? SmartSummonAvailable { get; set; }
    [JsonPropertyName("software_update")]
    public SoftwareUpdate SoftwareUpdate { get; set; }
    [JsonPropertyName("speed_limit_mode")]
    public SpeedLimitMode SpeedLimitMode { get; set; }
    [JsonPropertyName("summon_standby_mode_enabled")]
    public bool? SummonStandbyModeEnabled { get; set; }
    [JsonPropertyName("sun_roof_percent_open")]
    public int? SunRoofPercentOpen { get; set; }
    [JsonPropertyName("sun_roof_state")]
    public string SunRoofState { get; set; }
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
    [JsonPropertyName("valet_mode")]
    public bool? ValetMode { get; set; }
    [JsonPropertyName("valet_pin_needed")]
    public bool? ValetPinNeeded { get; set; }
    [JsonPropertyName("vehicle_name")]
    public string VehicleName { get; set; }
}