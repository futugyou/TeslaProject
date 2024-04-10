namespace TeslaApi.Vehicle.Abstractions;

public class VehicleOptions
{
    public string TeslaBaseUrl { get; set; } = "https://owner-api.teslamotors.com";
    public string TeslaEndPointHealthStatus { get; set; } = "status";
    public string Authenticate { get; set; } = "oauth/token";
    public string RevokeAuthToken { get; set; } = "oauth/revoke";
    public string ProductList { get; set; } = "api/1/products";
    public string VehicleList { get; set; } = "api/1/vehicles";
    public string VehicleDetail { get; set; } = "api/1/vehicles/{0}";

    #region vehicle/state
    public string VehicleData { get; set; } = "api/1/vehicles/{0}/vehicle_data";
    public string VehicleDataLegacy { get; set; } = "api/1/vehicles/{0}/data";
    public string MobileEnabled { get; set; } = "api/1/vehicles/{0}/mobile_enabled";
    public string NearbyChargingSites { get; set; } = "api/1/vehicles/{0}/nearby_charging_sites";
    public string ReleaseNotes { get; set; } = "api/1/vehicles/{0}/release_notes";
    #endregion

    #region  vehicle command
    public string WakeUp { get; set; } = "api/1/vehicles/{0}/wake_up";

    public string HonkHorn { get; set; } = "api/1/vehicles/{0}/command/honk_horn";

    public string FlashLights { get; set; } = "api/1/vehicles/{0}/command/flash_lights";

    public string RemoteStart { get; set; } = "api/1/vehicles/{0}/command/remote_start_drive";

    public string TriggerHomelink { get; set; } = "api/1/vehicles/{0}/command/trigger_homelink";

    public string SpeedLimitSetLimit { get; set; } = "api/1/vehicles/{0}/command/speed_limit_set_limit";
    public string SpeedLimitActivate { get; set; } = "api/1/vehicles/{0}/command/speed_limit_activate";
    public string SpeedLimitDeactivate { get; set; } = "api/1/vehicles/{0}/command/speed_limit_deactivate";
    public string SpeedLimitClearPin { get; set; } = "api/1/vehicles/{0}/command/speed_limit_clear_pin";

    public string SetValetMode { get; set; } = "api/1/vehicles/{0}/command/set_valet_mode";
    public string ResetValetPin { get; set; } = "api/1/vehicles/{0}/command/reset_valet_pin";

    public string SetSentryMode { get; set; } = "api/1/vehicles/{0}/command/set_sentry_mode";

    public string Unlock { get; set; } = "api/1/vehicles/{0}/command/door_unlock";
    public string Lock { get; set; } = "api/1/vehicles/{0}/command/door_lock";

    public string ActuateTrunk { get; set; } = "api/1/vehicles/{0}/command/actuate_trunk";

    public string WindowControl { get; set; } = "api/1/vehicles/{0}/command/window_control";

    public string ChangeSunroofState { get; set; } = "api/1/vehicles/{0}/command/sun_roof_control";

    public string ChargePortDoorOpen { get; set; } = "api/1/vehicles/{0}/command/charge_port_door_open";
    public string ChargePortDoorClose { get; set; } = "api/1/vehicles/{0}/command/charge_port_door_close";
    public string StartCharge { get; set; } = "api/1/vehicles/{0}/command/charge_start";
    public string StopCharge { get; set; } = "api/1/vehicles/{0}/command/charge_stop";
    public string ChargeStandard { get; set; } = "api/1/vehicles/{0}/command/charge_standard";
    public string ChargeMaxRange { get; set; } = "api/1/vehicles/{0}/command/charge_max_range";
    public string ChangeChargeLimit { get; set; } = "api/1/vehicles/{0}/command/set_charge_limit";
    public string SetChargingAmps { get; set; } = "api/1/vehicles/{0}/command/set_charging_amps";
    public string SetScheduledCharging { get; set; } = "api/1/vehicles/{0}/command/set_scheduled_charging";
    public string SetScheduledDeparture { get; set; } = "api/1/vehicles/{0}/command/set_scheduled_departure";

    public string ClimateOn { get; set; } = "api/1/vehicles/{0}/command/auto_conditioning_start";
    public string ClimateOff { get; set; } = "api/1/vehicles/{0}/command/auto_conditioning_stop";
    public string ChangeClimateTemperatureSetting { get; set; } = "api/1/vehicles/{0}/command/set_temps";
    public string MaxDefrost { get; set; } = "api/1/vehicles/{0}/command/set_preconditioning_max";
    public string RemoteSeatHeater { get; set; } = "api/1/vehicles/{0}/command/remote_seat_heater_request";
    public string RemoteSeatCooler { get; set; } = "api/1/vehicles/{0}/command/remote_seat_cooler_request";
    public string RemoteSteeringWheelHeater { get; set; } = "api/1/vehicles/{0}/command/remote_steering_wheel_heater_request";
    public string SetBioweaponMode { get; set; } = "api/1/vehicles/{0}/command/set_bioweapon_mode";
    public string SetClimateKeeperMode { get; set; } = "api/1/vehicles/{0}/command/set_climate_keeper_mode";
    public string RemoteAutoSeatClimate { get; set; } = "api/1/vehicles/{0}/command/remote_auto_seat_climate_request";
    public string SetCopTemp { get; set; } = "api/1/vehicles/{0}/command/set_cop_temp";
    public string SetCabinOverheatProtection { get; set; } = "api/1/vehicles/{0}/command/set_cabin_overheat_protection";

    public string MediaTogglePlayback { get; set; } = "api/1/vehicles/{0}/command/media_toggle_playback";
    public string MediaNextTrack { get; set; } = "api/1/vehicles/{0}/command/media_next_track";
    public string MediaPreviousTrack { get; set; } = "api/1/vehicles/{0}/command/media_prev_track";
    public string MediaNextFavorite { get; set; } = "api/1/vehicles/{0}/command/media_next_fav";
    public string MediaPreviousFavorite { get; set; } = "api/1/vehicles/{0}/command/media_prev_fav";
    public string MediaVolumeUp { get; set; } = "api/1/vehicles/{0}/command/media_volume_up";
    public string MediaVolumeDown { get; set; } = "api/1/vehicles/{0}/command/media_volume_down";
    public string AdjustVolume { get; set; } = "api/1/vehicles/{0}/command/adjust_volume";

    public string ShareToVehicle { get; set; } = "api/1/vehicles/{0}/command/share";

    public string ScheduleSoftwareUpdate { get; set; } = "api/1/vehicles/{0}/command/schedule_software_update";
    public string CancelSoftwareUpdate { get; set; } = "api/1/vehicles/{0}/command/cancel_software_update";
    #endregion
}
