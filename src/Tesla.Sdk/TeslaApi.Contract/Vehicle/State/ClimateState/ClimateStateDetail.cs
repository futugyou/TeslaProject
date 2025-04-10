﻿
namespace TeslaApi.Contract.Vehicle.State.ClimateState;

public class ClimateStateDetail
{
    [JsonPropertyName("battery_heater")]
    public bool BatteryHeater { get; set; }
    [JsonPropertyName("battery_heater_no_power")]
    public bool BatteryHeaterNoPower { get; set; }
    [JsonPropertyName("climate_keeper_mode")]
    public string ClimateKeeperMode { get; set; }
    [JsonPropertyName("defrost_mode")]
    public int DefrostMode { get; set; }
    [JsonPropertyName("driver_temp_setting")]
    public float DriverTempSetting { get; set; }
    [JsonPropertyName("fan_status")]
    public int FanStatus { get; set; }
    [JsonPropertyName("inside_temp")]
    public float InsideTemp { get; set; }
    [JsonPropertyName("is_auto_conditioning_on")]
    public bool IsAutoConditioningOn { get; set; }
    [JsonPropertyName("is_climate_on")]
    public bool IsClimateOn { get; set; }
    [JsonPropertyName("is_front_defroster_on")]
    public bool IsFrontDefrosterOn { get; set; }
    [JsonPropertyName("is_preconditioning")]
    public bool IsPreconditioning { get; set; }
    [JsonPropertyName("is_rear_defroster_on")]
    public bool IsRearDefrosterOn { get; set; }
    [JsonPropertyName("left_temp_direction")]
    public int LeftTempDirection { get; set; }
    [JsonPropertyName("max_avail_temp")]
    public float MaxAvailTemp { get; set; }
    [JsonPropertyName("min_avail_temp")]
    public float MinAvailTemp { get; set; }
    [JsonPropertyName("outside_temp")]
    public float OutsideTemp { get; set; }
    [JsonPropertyName("passenger_temp_setting")]
    public float PassengerTempSetting { get; set; }
    [JsonPropertyName("remote_heater_control_enabled")]
    public bool RemoteHeaterControlEnabled { get; set; }
    [JsonPropertyName("right_temp_direction")]
    public int RightTempDirection { get; set; }
    [JsonPropertyName("seat_heater_left")]
    public int SeatHeaterLeft { get; set; }
    [JsonPropertyName("seat_heater_right")]
    public int SeatHeaterRight { get; set; }
    [JsonPropertyName("side_mirror_heaters")]
    public bool SideMirrorHeaters { get; set; }
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
    [JsonPropertyName("wiper_blade_heater")]
    public bool WiperBladeHeater { get; set; }
}