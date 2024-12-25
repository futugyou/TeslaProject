
namespace TeslaApi.Contract.Vehicle.State.VehicleConfig;

public class VehicleConfigDetail
{
    [JsonPropertyName("can_accept_navigation_requests")]
    public bool? CanAcceptNavigationRequests { get; set; }
    [JsonPropertyName("can_actuate_trunks")]
    public bool? CanActuateTrunks { get; set; }
    [JsonPropertyName("car_special_type")]
    public string CarSpecialType { get; set; }
    [JsonPropertyName("car_type")]
    public string CarType { get; set; }
    [JsonPropertyName("charge_port_type")]
    public string ChargePortType { get; set; }
    [JsonPropertyName("default_charge_to_max")]
    public bool? DefaultChargeToMax { get; set; }
    [JsonPropertyName("driver_assist")]
    public string DriverAssist { get; set; }
    [JsonPropertyName("ece_restrictions")]
    public bool? EceRestrictions { get; set; }
    [JsonPropertyName("efficiency_package")]
    public string EfficiencyPackage { get; set; }
    [JsonPropertyName("eu_vehicle")]
    public bool? EuVehicle { get; set; }
    [JsonPropertyName("exterior_color")]
    public string ExteriorColor { get; set; }
    [JsonPropertyName("exterior_trim")]
    public string ExteriorTrim { get; set; }
    [JsonPropertyName("has_air_suspension")]
    public bool? HasAirSuspension { get; set; }
    [JsonPropertyName("has_ludicrous_mode")]
    public bool? HasLudicrousMode { get; set; }
    [JsonPropertyName("interior_trim_type")]
    public string InteriorTrimType { get; set; }
    [JsonPropertyName("key_version")]
    public int? KeyVersion { get; set; }
    [JsonPropertyName("motorized_charge_port")]
    public bool? MotorizedChargePort { get; set; }
    [JsonPropertyName("performance_package")]
    public string PerformancePackage { get; set; }
    [JsonPropertyName("plg")]
    public bool? Plg { get; set; }
    [JsonPropertyName("rear_drive_unit")]
    public string RearDriveUnit { get; set; }
    [JsonPropertyName("rear_seat_heaters")]
    public int? RearSeatHeaters { get; set; }
    [JsonPropertyName("rear_seat_type")]
    public object RearSeatType { get; set; }
    [JsonPropertyName("rhd")]
    public bool? Rhd { get; set; }
    [JsonPropertyName("roof_color")]
    public string RoofColor { get; set; }
    [JsonPropertyName("seat_type")]
    public int? SeatType { get; set; }
    [JsonPropertyName("spoiler_type")]
    public string SpoilerType { get; set; }
    [JsonPropertyName("sun_roof_installed")]
    public object SunRoofInstalled { get; set; }
    [JsonPropertyName("third_row_seats")]
    public string ThirdRowSeats { get; set; }
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
    [JsonPropertyName("trim_badging")]
    public string TrimBadging { get; set; }
    [JsonPropertyName("use_range_badging")]
    public bool? UseRangeBadging { get; set; }
    [JsonPropertyName("wheel_type")]
    public string WheelType { get; set; }
}