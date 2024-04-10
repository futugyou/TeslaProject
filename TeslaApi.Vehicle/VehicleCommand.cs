using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeslaApi.Contract;
using TeslaApi.Contract.Vehicle.Commands.Alerts;
using TeslaApi.Contract.Vehicle.Commands.Charging;
using TeslaApi.Contract.Vehicle.Commands.Climate;
using TeslaApi.Contract.Vehicle.Commands.Doors;
using TeslaApi.Contract.Vehicle.Commands.FrunkTrunk;
using TeslaApi.Contract.Vehicle.Commands.Homelink;
using TeslaApi.Contract.Vehicle.Commands.Media;
using TeslaApi.Contract.Vehicle.Commands.RemoteStart;
using TeslaApi.Contract.Vehicle.Commands.SentryMode;
using TeslaApi.Contract.Vehicle.Commands.Sharing;
using TeslaApi.Contract.Vehicle.Commands.SoftwareUpdates;
using TeslaApi.Contract.Vehicle.Commands.SpeedLimit;
using TeslaApi.Contract.Vehicle.Commands.Sunroof;
using TeslaApi.Contract.Vehicle.Commands.ValetMode;
using TeslaApi.Contract.Vehicle.Commands.Wake;
using TeslaApi.Contract.Vehicle.Commands.Windows;
using TeslaApi.Vehicle.Abstractions;

namespace TeslaApi.Vehicle;

public class VehicleCommand : IVehicleCommand
{
    private readonly ILogger<VehicleCommand> _logger;
    private readonly VehicleOptions _options;
    private readonly HttpClient httpClient;

    public VehicleCommand(ILogger<VehicleCommand> logger,
        IOptionsMonitor<VehicleOptions> options,
        IHttpClientFactory clientFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        options = options ?? throw new ArgumentNullException(nameof(options));
        clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

        _options = options.CurrentValue;
        httpClient = clientFactory.CreateClient(TeslaApiConst.TESLA_SERVICE_HTTPCLIENT_NAME);
        httpClient.BaseAddress = new Uri(_options.TeslaBaseUrl);
    }

    public async Task<VehicleWakeResponse> WakeupVehicle(string id, string token)
    {
        var url = string.Format(_options.WakeUp, id);
        return await httpClient.UtilsPostAsync<VehicleWakeResponse>(url, token);
    }

    public async Task<AlertsResponse> HonkHornAlerts(string id, string token)
    {
        var url = string.Format(_options.HonkHorn, id);
        return await httpClient.UtilsPostAsync<AlertsResponse>(url, token);
    }

    public async Task<AlertsResponse> FlashLightsAlerts(string id, string token)
    {
        var url = string.Format(_options.FlashLights, id);
        return await httpClient.UtilsPostAsync<AlertsResponse>(url, token);
    }

    public async Task<RemoteStartResponse> RemoteStartDrive(string id, RemoteStartRequest request, string token)
    {
        var url = string.Format(_options.RemoteStart, id);
        return await httpClient.UtilsPostAsync<RemoteStartRequest, RemoteStartResponse>(request, url, token);
    }

    public async Task<HomelinkResponse> TriggerHomelink(string id, HomelinkRequest request, string token)
    {
        var url = string.Format(_options.TriggerHomelink, id);
        return await httpClient.UtilsPostAsync<HomelinkRequest, HomelinkResponse>(request, url, token);
    }

    public async Task<SpeedLimitResponse> SpeedLimitSetLimit(string id, SpeedLimitRequest request, string token)
    {
        var url = string.Format(_options.SpeedLimitSetLimit, id);
        return await httpClient.UtilsPostAsync<SpeedLimitRequest, SpeedLimitResponse>(request, url, token);
    }

    public async Task<SpeedLimitResponse> SpeedLimitActivate(string id, SpeedLimitWithPinRequest request, string token)
    {
        var url = string.Format(_options.SpeedLimitActivate, id);
        return await httpClient.UtilsPostAsync<SpeedLimitWithPinRequest, SpeedLimitResponse>(request, url, token);
    }

    public async Task<SpeedLimitResponse> SpeedLimitDeactivate(string id, SpeedLimitWithPinRequest request, string token)
    {
        var url = string.Format(_options.SpeedLimitDeactivate, id);
        return await httpClient.UtilsPostAsync<SpeedLimitWithPinRequest, SpeedLimitResponse>(request, url, token);
    }

    public async Task<SpeedLimitResponse> SpeedLimitClearPin(string id, SpeedLimitWithPinRequest request, string token)
    {
        var url = string.Format(_options.SpeedLimitClearPin, id);
        return await httpClient.UtilsPostAsync<SpeedLimitWithPinRequest, SpeedLimitResponse>(request, url, token);
    }

    public async Task<ValetModeResponse> SetValetMode(string id, ValetModeRequest request, string token)
    {
        var url = string.Format(_options.SetValetMode, id);
        return await httpClient.UtilsPostAsync<ValetModeRequest, ValetModeResponse>(request, url, token);
    }

    public async Task<ValetModeResponse> ResetValetPin(string id, ValetModeRequest request, string token)
    {
        var url = string.Format(_options.ResetValetPin, id);
        return await httpClient.UtilsPostAsync<ValetModeRequest, ValetModeResponse>(request, url, token);
    }

    public async Task<SentryModeResponse> SetSentryMode(string id, SentryModeRequest request, string token)
    {
        var url = string.Format(_options.SetSentryMode, id);
        return await httpClient.UtilsPostAsync<SentryModeRequest, SentryModeResponse>(request, url, token);
    }

    public async Task<DoorsResponse> DoorUnlock(string id, string token)
    {
        var url = string.Format(_options.Unlock, id);
        return await httpClient.UtilsPostAsync<DoorsResponse>(url, token);
    }

    public async Task<DoorsResponse> DoorLock(string id, string token)
    {
        var url = string.Format(_options.Lock, id);
        return await httpClient.UtilsPostAsync<DoorsResponse>(url, token);
    }

    public async Task<FrunkTrunkResponse> ActuateTrunk(string id, FrunkTrunkRequest request, string token)
    {
        var url = string.Format(_options.ActuateTrunk, id);
        return await httpClient.UtilsPostAsync<FrunkTrunkRequest, FrunkTrunkResponse>(request, url, token);
    }

    public async Task<WindowsResponse> WindowControl(string id, WindowsRequest request, string token)
    {
        var url = string.Format(_options.WindowControl, id);
        return await httpClient.UtilsPostAsync<WindowsRequest, WindowsResponse>(request, url, token);
    }

    public async Task<SunroofResponse> SunRoofControl(string id, SunroofRequest request, string token)
    {
        var url = string.Format(_options.ChangeSunroofState, id);
        return await httpClient.UtilsPostAsync<SunroofRequest, SunroofResponse>(request, url, token);
    }

    public async Task<ChargingResponse> ChargePortDoorOpen(string id, string token)
    {
        var url = string.Format(_options.ChargePortDoorOpen, id);
        return await httpClient.UtilsPostAsync<ChargingResponse>(url, token);
    }

    public async Task<ChargingResponse> ChargePortDoorClose(string id, string token)
    {
        var url = string.Format(_options.ChargePortDoorClose, id);
        return await httpClient.UtilsPostAsync<ChargingResponse>(url, token);
    }

    public async Task<ChargingResponse> ChargeStart(string id, string token)
    {
        var url = string.Format(_options.StartCharge, id);
        return await httpClient.UtilsPostAsync<ChargingResponse>(url, token);
    }

    public async Task<ChargingResponse> ChargeStop(string id, string token)
    {
        var url = string.Format(_options.StopCharge, id);
        return await httpClient.UtilsPostAsync<ChargingResponse>(url, token);
    }

    public async Task<ChargingResponse> ChargeStandard(string id, string token)
    {
        var url = string.Format(_options.ChargeStandard, id);
        return await httpClient.UtilsPostAsync<ChargingResponse>(url, token);
    }

    public async Task<ChargingResponse> ChargeMaxRange(string id, string token)
    {
        var url = string.Format(_options.ChargeMaxRange, id);
        return await httpClient.UtilsPostAsync<ChargingResponse>(url, token);
    }

    public async Task<ChargingResponse> SetChargeLimit(string id, ChargingRequest request, string token)
    {
        var url = string.Format(_options.ChangeChargeLimit, id);
        return await httpClient.UtilsPostAsync<ChargingRequest, ChargingResponse>(request, url, token);
    }

    public Task<ChargingResponse> SetChargingAmps(string id, SetChargingAmpsRequest request, string token)
    {
        var url = string.Format(_options.SetChargingAmps, id);
        return httpClient.UtilsPostAsync<SetChargingAmpsRequest, ChargingResponse>(request, url, token);
    }

    public Task<ChargingResponse> SetScheduledCharging(string id, SetScheduledChargingRequest request, string token)
    {
        var url = string.Format(_options.SetScheduledCharging, id);
        return httpClient.UtilsPostAsync<SetScheduledChargingRequest, ChargingResponse>(request, url, token);
    }

    public Task<ChargingResponse> SetScheduledDeparture(string id, SetScheduledDepartureRequest request, string token)
    {
        var url = string.Format(_options.SetScheduledDeparture, id);
        return httpClient.UtilsPostAsync<SetScheduledDepartureRequest, ChargingResponse>(request, url, token);
    }

    public async Task<ClimateResponse> AutoConditioningStart(string id, string token)
    {
        var url = string.Format(_options.ClimateOn, id);
        return await httpClient.UtilsPostAsync<ClimateResponse>(url, token);
    }

    public async Task<ClimateResponse> AutoConditioningStop(string id, string token)
    {
        var url = string.Format(_options.ClimateOff, id);
        return await httpClient.UtilsPostAsync<ClimateResponse>(url, token);
    }

    public async Task<ClimateResponse> SetTemps(string id, SetTempsRequest request, string token)
    {
        var url = string.Format(_options.ChangeClimateTemperatureSetting, id);
        return await httpClient.UtilsPostAsync<SetTempsRequest, ClimateResponse>(request, url, token);
    }

    public async Task<ClimateResponse> SetPreconditioningMax(string id, SetPreconditioningMaxRequest request, string token)
    {
        var url = string.Format(_options.MaxDefrost, id);
        return await httpClient.UtilsPostAsync<SetPreconditioningMaxRequest, ClimateResponse>(request, url, token);
    }

    public async Task<ClimateResponse> RemoteSeatHeater(string id, RemoteSeatHeaterRequest request, string token)
    {
        var url = string.Format(_options.RemoteSeatHeater, id);
        return await httpClient.UtilsPostAsync<RemoteSeatHeaterRequest, ClimateResponse>(request, url, token);
    }

    public Task<ClimateResponse> RemoteSeatCooler(string id, RemoteSeatCoolerRequest request, string token)
    {
        var url = string.Format(_options.RemoteSeatCooler, id);
        return httpClient.UtilsPostAsync<RemoteSeatCoolerRequest, ClimateResponse>(request, url, token);
    }

    public Task<ClimateResponse> SetBioweaponMode(string id, SetBioweaponModeRequest request, string token)
    {
        var url = string.Format(_options.SetBioweaponMode, id);
        return httpClient.UtilsPostAsync<SetBioweaponModeRequest, ClimateResponse>(request, url, token);
    }

    public Task<ClimateResponse> SetClimateKeeperMode(string id, SetClimateKeeperModeRequest request, string token)
    {
        var url = string.Format(_options.SetClimateKeeperMode, id);
        return httpClient.UtilsPostAsync<SetClimateKeeperModeRequest, ClimateResponse>(request, url, token);
    }

    public async Task<ClimateResponse> RemoteSteeringWheelHeater(string id, RemoteSteeringWheelHeaterRequest request, string token)
    {
        var url = string.Format(_options.RemoteSteeringWheelHeater, id);
        return await httpClient.UtilsPostAsync<RemoteSteeringWheelHeaterRequest, ClimateResponse>(request, url, token);
    }

    public Task<ClimateResponse> RemoteAutoSeatClimate(string id, RemoteAutoSeatClimateRequest request, string token)
    {
        var url = string.Format(_options.RemoteAutoSeatClimate, id);
        return httpClient.UtilsPostAsync<RemoteAutoSeatClimateRequest, ClimateResponse>(request, url, token);
    }

    public Task<ClimateResponse> SetCopTemp(string id, SetCopTempRequest request, string token)
    {
        var url = string.Format(_options.SetCopTemp, id);
        return httpClient.UtilsPostAsync<SetCopTempRequest, ClimateResponse>(request, url, token);
    }

    public Task<ClimateResponse> SetCabinOverheatProtection(string id, SetCabinOverheatProtectionRequest request, string token)
    {
        var url = string.Format(_options.SetCabinOverheatProtection, id);
        return httpClient.UtilsPostAsync<SetCabinOverheatProtectionRequest, ClimateResponse>(request, url, token);
    }

    public async Task<MediaResponse> MediaTogglePlayback(string id, string token)
    {
        var url = string.Format(_options.MediaTogglePlayback, id);
        return await httpClient.UtilsPostAsync<MediaResponse>(url, token);
    }

    public async Task<MediaResponse> MediaNextTrack(string id, string token)
    {
        var url = string.Format(_options.MediaNextTrack, id);
        return await httpClient.UtilsPostAsync<MediaResponse>(url, token);
    }

    public async Task<MediaResponse> MediaPrevTrack(string id, string token)
    {
        var url = string.Format(_options.MediaPreviousTrack, id);
        return await httpClient.UtilsPostAsync<MediaResponse>(url, token);
    }

    public async Task<MediaResponse> MediaNextFav(string id, string token)
    {
        var url = string.Format(_options.MediaNextFavorite, id);
        return await httpClient.UtilsPostAsync<MediaResponse>(url, token);
    }

    public async Task<MediaResponse> MediaPrevFav(string id, string token)
    {
        var url = string.Format(_options.MediaPreviousFavorite, id);
        return await httpClient.UtilsPostAsync<MediaResponse>(url, token);
    }

    public async Task<MediaResponse> MediaVolumeUp(string id, string token)
    {
        var url = string.Format(_options.MediaVolumeUp, id);
        return await httpClient.UtilsPostAsync<MediaResponse>(url, token);
    }

    public async Task<MediaResponse> MediaVolumeDown(string id, string token)
    {
        var url = string.Format(_options.MediaVolumeDown, id);
        return await httpClient.UtilsPostAsync<MediaResponse>(url, token);
    }

    public Task<MediaResponse> AdjustVolume(string id, AdjustVolumeRequest request, string token)
    {
        var url = string.Format(_options.AdjustVolume, id);
        return httpClient.UtilsPostAsync<AdjustVolumeRequest, MediaResponse>(request, url, token);
    }


    public async Task<SharingResponse> ShareToVehicle(string id, SharingRequest request, string token)
    {
        var url = string.Format(_options.ShareToVehicle, id);
        return await httpClient.UtilsPostAsync<SharingRequest, SharingResponse>(request, url, token);
    }

    public async Task<SoftwareUpdatesResponse> ScheduleSoftwareUupdate(string id, ScheduleSoftwareUpdateRequest request, string token)
    {
        var url = string.Format(_options.ScheduleSoftwareUpdate, id);
        return await httpClient.UtilsPostAsync<ScheduleSoftwareUpdateRequest, SoftwareUpdatesResponse>(request, url, token);
    }

    public async Task<SoftwareUpdatesResponse> CancelSoftwareUpdate(string id, string token)
    {
        var url = string.Format(_options.CancelSoftwareUpdate, id);
        return await httpClient.UtilsPostAsync<SoftwareUpdatesResponse>(url, token);
    }
 
}
