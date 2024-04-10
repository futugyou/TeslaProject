﻿namespace TeslaApi.Vehicle.Abstractions;

public class VehicleOptions
{
    public string TeslaBaseUrl { get; set; } = "https://owner-api.teslamotors.com";
    public string TeslaEndPointHealthStatus { get; set; } = "status";
    public string Authenticate { get; set; } = "oauth/token";
    public string RevokeAuthToken { get; set; } = "oauth/revoke";
    public string ProductList { get; set; } = "api/1/products";
    public string VehicleList { get; set; } = "api/1/vehicles";
    public string VehicleDetail { get; set; } = "api/1/vehicles/{0}";
    public string VehicleDataLegacy { get; set; } = "api/1/vehicles/{0}/data";
    public string VehicleData { get; set; } = "api/1/vehicles/{0}/vehicle_data";
    public string ChargeState { get; set; } = "/api/1/vehicles/{0}/data_request/charge_state";
    public string ClimateState { get; set; } = "/api/1/vehicles/{0}/data_request/climate_state";
    public string DriveState { get; set; } = "/api/1/vehicles/{0}/data_request/drive_state";
    public string GuiSettings { get; set; } = "/api/1/vehicles/{0}/data_request/gui_settings";
    public string VehicleState { get; set; } = "/api/1/vehicles/{0}/data_request/vehicle_state";
    public string VehicleConfig { get; set; } = "/api/1/vehicles/{0}/data_request/vehicle_config"; 
    public string MobileEnabled { get; set; } = "api/1/vehicles/{0}/mobile_enabled";
    public string NearbyChargingSites { get; set; } = "api/1/vehicles/{0}/nearby_charging_sites";
    public string ReleaseNotes { get; set; } = "api/1/vehicles/{0}/release_notes";
    public string WakeUp { get; set; } = "api/1/vehicles/{0}/wake_up";
    public string Unlock { get; set; } = "api/1/vehicles/{0}/command/door_unlock";
    public string Lock { get; set; } = "api/1/vehicles/{0}/command/door_lock";
    public string HonkHorn { get; set; } = "api/1/vehicles/{0}/command/honk_horn";
    public string FlashLights { get; set; } = "api/1/vehicles/{0}/command/flash_lights";
    public string ClimateOn { get; set; } = "api/1/vehicles/{0}/command/auto_conditioning_start";
    public string ClimateOff { get; set; } = "api/1/vehicles/{0}/command/auto_conditioning_stop";
    public string MaxDefrost { get; set; } = "api/1/vehicles/{0}/command/set_preconditioning_max";
    public string ChangeClimateTemperatureSetting { get; set; } = "api/1/vehicles/{0}/command/set_temps";
    public string ChangeChargeLimit { get; set; } = "api/1/vehicles/{0}/command/set_charge_limit";
    public string ChangeSunroofState { get; set; } = "api/1/vehicles/{0}/command/sun_roof_control";
    public string WindowControl { get; set; } = "api/1/vehicles/{0}/command/window_control";
    public string ActuateTrunk { get; set; } = "api/1/vehicles/{0}/command/actuate_trunk";
    public string RemoteStart { get; set; } = "api/1/vehicles/{0}/command/remote_start_drive";
    public string TriggerHomelink { get; set; } = "api/1/vehicles/{0}/command/trigger_homelink";
    public string ChargePortDoorOpen { get; set; } = "api/1/vehicles/{0}/command/charge_port_door_open";
    public string ChargePortDoorClose { get; set; } = "api/1/vehicles/{0}/command/charge_port_door_close";
    public string StartCharge { get; set; } = "api/1/vehicles/{0}/command/charge_start";
    public string StopCharge { get; set; } = "api/1/vehicles/{0}/command/charge_stop";
    public string ChargeStandard { get; set; } = "api/1/vehicles/{0}/command/charge_standard";
    public string ChargeMaxRange { get; set; } = "api/1/vehicles/{0}/command/charge_max_range";
    public string MediaTogglePlayback { get; set; } = "api/1/vehicles/{0}/command/media_toggle_playback";
    public string MediaNextTrack { get; set; } = "api/1/vehicles/{0}/command/media_next_track";
    public string MediaPreviousTrack { get; set; } = "api/1/vehicles/{0}/command/media_prev_track";
    public string MediaNextFavorite { get; set; } = "api/1/vehicles/{0}/command/media_next_fav";
    public string MediaPreviousFavorite { get; set; } = "api/1/vehicles/{0}/command/media_prev_fav";
    public string MediaVolumeUp { get; set; } = "api/1/vehicles/{0}/command/media_volume_up";
    public string MediaVolumeDown { get; set; } = "api/1/vehicles/{0}/command/media_volume_down";
    public string SendLog { get; set; } = "api/1/logs";
    public string SendReport { get; set; } = "api/1/reports";
    public string RetrieveNotificationPreferences { get; set; } = "api/1/notification_preferences";
    public string SendNotificationPreferences { get; set; } = "api/1/notification_preferences";
    public string RetrieveNotificationSubscriptionPreferences { get; set; } = "api/1/vehicle_subscriptions";
    public string SendNotificationSubscriptionPreferences { get; set; } = "api/1/vehicle_subscriptions";
    public string DeactivateDeviceToken { get; set; } = "api/1/device/{0}/deactivate";
    public string CalendarSync { get; set; } = "api/1/vehicles/{0}/command/upcoming_calendar_entries";
    public string SetValetMode { get; set; } = "api/1/vehicles/{0}/command/set_valet_mode";
    public string ResetValetPin { get; set; } = "api/1/vehicles/{0}/command/reset_valet_pin";
    public string SpeedLimitActivate { get; set; } = "api/1/vehicles/{0}/command/speed_limit_activate";
    public string SpeedLimitDeactivate { get; set; } = "api/1/vehicles/{0}/command/speed_limit_deactivate";
    public string SpeedLimitSetLimit { get; set; } = "api/1/vehicles/{0}/command/speed_limit_set_limit";
    public string SpeedLimitClearPin { get; set; } = "api/1/vehicles/{0}/command/speed_limit_clear_pin";
    public string ScheduleSoftwareUpdate { get; set; } = "api/1/vehicles/{0}/command/schedule_software_update";
    public string CancelSoftwareUpdate { get; set; } = "api/1/vehicles/{0}/command/cancel_software_update";
    public string SetSentryMode { get; set; } = "api/1/vehicles/{0}/command/set_sentry_mode";
    public string PowerwallOrderSessionData { get; set; } = "api/1/users/powerwall_order_entry_data";
    public string PowerwallOrderPage { get; set; } = "powerwall_order_page";
    public string OnboardingExperience { get; set; } = "api/1/users/onboarding_data";
    public string OnboardingExperiencePage { get; set; } = "onboarding_page";
    public string ServiceSelfSchedulingEligibility { get; set; } = "api/1/users/service_scheduling_data";
    public string ServiceSelfSchedulingPage { get; set; } = "service_scheduling_page";
    public string ReferralData { get; set; } = "api/1/users/referral_data";
    public string ReferralPage { get; set; } = "referral_page";
    public string RoadsideAssistanceData { get; set; } = "api/1/users/roadside_assistance_data";
    public string RoadsideAssistancePage { get; set; } = "roadside_assistance_page";
    public string UpgradeEligibility { get; set; } = "api/1/vehicles/{0}/eligible_upgrades";
    public string UpgradesPage { get; set; } = "upgrades_page";
    public string MessageCenterMessageList { get; set; } = "api/1/messages";
    public string MessageCenterMessage { get; set; } = "api/1/messages/{0}";
    public string MessageCenterCounts { get; set; } = "api/1/messages/count";
    public string MessageCenterMessageActionUpdate { get; set; } = "api/1/messages/{0}/actions";
    public string MessageCenterCtaPage { get; set; } = "messages_cta_page";
    public string AuthCommandToken { get; set; } = "api/1/users/command_token";
    public string SendDeviceKey { get; set; } = "api/1/users/keys";
    public string DiagnosticsEntitlements { get; set; } = "api/1/diagnostics";
    public string SendDiagnostics { get; set; } = "api/1/diagnostics";
    public string BatterySummary { get; set; } = "api/1/powerwalls/{0}/status";
    public string BatteryData { get; set; } = "api/1/powerwalls/{0}";
    public string BatteryPowerTimeseriesData { get; set; } = "api/1/powerwalls/{0}/powerhistory";
    public string BatteryEnergyTimeseriesData { get; set; } = "api/1/powerwalls/{0}/energyhistory";
    public string BatteryBackupReserve { get; set; } = "api/1/powerwalls/{0}/backup";
    public string BatterySiteName { get; set; } = "api/1/powerwalls/{0}/site_name";
    public string BatteryOperationMode { get; set; } = "api/1/powerwalls/{0}/operation";
    public string SiteSummary { get; set; } = "api/1/energy_sites/{0}/status";
    public string SiteData { get; set; } = "api/1/energy_sites/{0}/live_status";
    public string SiteConfig { get; set; } = "api/1/energy_sites/{0}/site_info";
    public string EnergyServiceSchedulingPage { get; set; } = "energy_service_scheduling_page";
    public string HistoryData { get; set; } = "api/1/energy_sites/{0}/history";
    public string CalendarHistoryData { get; set; } = "api/1/energy_sites/{0}/calendar_history";
    public string SavingsForecast { get; set; } = "api/1/energy_sites/{0}/savings_forecast";
    public string TariffRates { get; set; } = "api/1/energy_sites/{0}/tariff_rates";
    public string BackupReserve { get; set; } = "api/1/energy_sites/{0}/backup";
    public string OffGridVehicleChargingReserve { get; set; } = "api/1/energy_sites/{0}/off_grid_vehicle_charging_reserve";
    public string SiteName { get; set; } = "api/1/energy_sites/{0}/site_name";
    public string OperationMode { get; set; } = "api/1/energy_sites/{0}/operation";
    public string TimeOfUseSettings { get; set; } = "api/1/energy_sites/{0}/time_of_use_settings";
    public string StormModeSettings { get; set; } = "api/1/energy_sites/{0}/storm_mode";
    public string SendNotificationConfirmation { get; set; } = "api/1/notification_confirmations";
    public string ShareToVehicle { get; set; } = "api/1/vehicles/{0}/command/share";
    public string RemoteSeatHeaterRequest { get; set; } = "api/1/vehicles/{0}/command/remote_seat_heater_request";
    public string RemoteSteeringWheelHeaterRequest { get; set; } = "api/1/vehicles/{0}/command/remote_steering_wheel_heater_request";
}
