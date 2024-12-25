namespace TeslaApi.SDK;

public interface IVehicleCommand : IVehicleRefit
{
    [Post("/api/1/vehicles/{id}/wake_up")]
    Task<VehicleWakeResponse> WakeupVehicle(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/honk_horn")]
    Task<AlertsResponse> HonkHornAlerts(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/flash_lights")]
    Task<AlertsResponse> FlashLightsAlerts(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/remote_start_drive")]
    Task<RemoteStartResponse> RemoteStartDrive(string id, [Body] RemoteStartRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/trigger_homelink")]
    Task<HomelinkResponse> TriggerHomelink(string id, [Body] HomelinkRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/speed_limit_set_limit")]
    Task<SpeedLimitResponse> SpeedLimitSetLimit(string id, [Body] SpeedLimitRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/speed_limit_activate")]
    Task<SpeedLimitResponse> SpeedLimitActivate(string id, [Body] SpeedLimitWithPinRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/speed_limit_deactivate")]
    Task<SpeedLimitResponse> SpeedLimitDeactivate(string id, [Body] SpeedLimitWithPinRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/speed_limit_clear_pin")]
    Task<SpeedLimitResponse> SpeedLimitClearPin(string id, [Body] SpeedLimitWithPinRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_valet_mode")]
    Task<ValetModeResponse> SetValetMode(string id, [Body] ValetModeRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/reset_valet_pin")]
    Task<ValetModeResponse> ResetValetPin(string id, [Body] ValetModeRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_sentry_mode")]
    Task<SentryModeResponse> SetSentryMode(string id, [Body] SentryModeRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/door_unlock")]
    Task<DoorsResponse> DoorUnlock(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/door_lock")]
    Task<DoorsResponse> DoorLock(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/actuate_trunk")]
    Task<FrunkTrunkResponse> ActuateTrunk(string id, [Body] FrunkTrunkRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/window_control")]
    Task<WindowsResponse> WindowControl(string id, [Body] WindowsRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/sun_roof_control")]
    Task<SunroofResponse> SunRoofControl(string id, [Body] SunroofRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/charge_port_door_open")]
    Task<ChargingResponse> ChargePortDoorOpen(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/charge_port_door_close")]
    Task<ChargingResponse> ChargePortDoorClose(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/charge_start")]
    Task<ChargingResponse> ChargeStart(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/charge_stop")]
    Task<ChargingResponse> ChargeStop(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/charge_standard")]
    Task<ChargingResponse> ChargeStandard(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/charge_max_range")]
    Task<ChargingResponse> ChargeMaxRange(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_charge_limit")]
    Task<ChargingResponse> SetChargeLimit(string id, [Body] ChargingRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_charging_amps")]
    Task<ChargingResponse> SetChargingAmps(string id, [Body] SetChargingAmpsRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_scheduled_charging")]
    Task<ChargingResponse> SetScheduledCharging(string id, [Body] SetScheduledChargingRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_scheduled_departure")]
    Task<ChargingResponse> SetScheduledDeparture(string id, [Body] SetScheduledDepartureRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/auto_conditioning_start")]
    Task<ClimateResponse> AutoConditioningStart(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/auto_conditioning_stop")]
    Task<ClimateResponse> AutoConditioningStop(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_temps")]
    Task<ClimateResponse> SetTemps(string id, [Body] SetTempsRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_preconditioning_max")]
    Task<ClimateResponse> SetPreconditioningMax(string id, [Body] SetPreconditioningMaxRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/remote_seat_heater_request")]
    Task<ClimateResponse> RemoteSeatHeater(string id, [Body] RemoteSeatHeaterRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/remote_seat_cooler_request")]
    Task<ClimateResponse> RemoteSeatCooler(string id, [Body] RemoteSeatCoolerRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/remote_steering_wheel_heater_request")]
    Task<ClimateResponse> RemoteSteeringWheelHeater(string id, [Body] RemoteSteeringWheelHeaterRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_bioweapon_mode")]
    Task<ClimateResponse> SetBioweaponMode(string id, [Body] SetBioweaponModeRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_climate_keeper_mode")]
    Task<ClimateResponse> SetClimateKeeperMode(string id, [Body] SetClimateKeeperModeRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/remote_auto_seat_climate_request")]
    Task<ClimateResponse> RemoteAutoSeatClimate(string id, [Body] RemoteAutoSeatClimateRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_cop_temp")]
    Task<ClimateResponse> SetCopTemp(string id, [Body] SetCopTempRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/set_cabin_overheat_protection")]
    Task<ClimateResponse> SetCabinOverheatProtection(string id, [Body] SetCabinOverheatProtectionRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/media_toggle_playback")]
    Task<MediaResponse> MediaTogglePlayback(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/media_next_track")]
    Task<MediaResponse> MediaNextTrack(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/media_prev_track")]
    Task<MediaResponse> MediaPrevTrack(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/media_next_fav")]
    Task<MediaResponse> MediaNextFav(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/media_prev_fav")]
    Task<MediaResponse> MediaPrevFav(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/media_volume_up")]
    Task<MediaResponse> MediaVolumeUp(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/media_volume_down")]
    Task<MediaResponse> MediaVolumeDown(string id, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/adjust_volume")]
    Task<MediaResponse> AdjustVolume(string id, [Body] AdjustVolumeRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/share")]
    Task<SharingResponse> ShareToVehicle(string id, [Body] SharingRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/schedule_software_update")]
    Task<SoftwareUpdatesResponse> ScheduleSoftwareUupdate(string id, [Body] ScheduleSoftwareUpdateRequest request, [Authorize("Bearer")] string token);

    [Post("/api/1/vehicles/{id}/command/cancel_software_update")]
    Task<SoftwareUpdatesResponse> CancelSoftwareUpdate(string id, [Authorize("Bearer")] string token);
}
