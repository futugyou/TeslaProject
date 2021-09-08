using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaApi.Contract.Vehicle.Commands.Alerts;
using TeslaApi.Contract.Vehicle.Commands.Charging;
using TeslaApi.Contract.Vehicle.Commands.Climate;
using TeslaApi.Contract.Vehicle.Commands.Doors;
using TeslaApi.Contract.Vehicle.Commands.FrunkTrunk;
using TeslaApi.Contract.Vehicle.Commands.Homelink;
using TeslaApi.Contract.Vehicle.Commands.RemoteStart;
using TeslaApi.Contract.Vehicle.Commands.SentryMode;
using TeslaApi.Contract.Vehicle.Commands.SpeedLimit;
using TeslaApi.Contract.Vehicle.Commands.Sunroof;
using TeslaApi.Contract.Vehicle.Commands.ValetMode;
using TeslaApi.Contract.Vehicle.Commands.Wake;
using TeslaApi.Contract.Vehicle.Commands.Windows;

namespace TeslaApi.Vehicle.Abstractions
{
    public interface IVehcleCommand
    {
        Task<VehicleWakeResponse> WakeupVehicle(string id, string token);
        Task<AlertsResponse> HonkHornAlerts(string id, string token);
        Task<AlertsResponse> FlashLightsAlerts(string id, string token);
        Task<RemoteStartResponse> RemoteStartDrive(string id, RemoteStartRequest request, string token);
        /// <summary>
        ///  no test
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<HomelinkResponse> TriggerHomelink(string id, HomelinkRequest request, string token);
        Task<SpeedLimitResponse> SpeedLimitSetLimit(string id, SpeedLimitRequest request, string token);
        Task<SpeedLimitResponse> SpeedLimitActivate(string id, SpeedLimitWithPinRequest request, string token);
        Task<SpeedLimitResponse> SpeedLimitDeactivate(string id, SpeedLimitWithPinRequest request, string token);
        Task<SpeedLimitResponse> SpeedLimitClearPin(string id, SpeedLimitWithPinRequest request, string token);
        Task<ValetModeResponse> SetValetMode(string id, ValetModeRequest request, string token);
        Task<ValetModeResponse> ResetValetPin(string id, ValetModeRequest request, string token);
        Task<SentryModeResponse> SetSentryMode(string id, SentryModeRequest request, string token);
        Task<DoorsResponse> DoorUnlock(string id, string token);
        Task<DoorsResponse> DoorLock(string id, string token);
        Task<FrunkTrunkResponse> ActuateTrunk(string id, FrunkTrunkRequest request, string token);
        Task<WindowsResponse> WindowControl(string id, WindowsRequest request, string token);
        Task<SunroofResponse> SunRoofControl(string id, SunroofRequest request, string token);
        Task<ChargingResponse> ChargePortDoorOpen(string id, string token);
        Task<ChargingResponse> ChargePortDoorClose(string id, string token);
        Task<ChargingResponse> ChargeStart(string id, string token);
        Task<ChargingResponse> ChargeStop(string id, string token);
        Task<ChargingResponse> ChargeStandard(string id, string token);
        Task<ChargingResponse> ChargeMaxRange(string id, string token);
        Task<ChargingResponse> SetChargeLimit(string id, ChargingRequest request, string token);
        Task<ClimateResponse> AutoConditioningStart(string id, string token);
        Task<ClimateResponse> AutoConditioningStop(string id, string token);
        Task<ClimateResponse> SetTemps(string id, SetTempsRequest request, string token);
        Task<ClimateResponse> SetPreconditioningMax(string id, SetPreconditioningMaxRequest request, string token);
        Task<ClimateResponse> RemoteSeatHeater(string id, RemoteSeatHeaterRequest request, string token);
        Task<ClimateResponse> RemoteSteeringWheelHeater(string id, RemoteSteeringWheelHeaterRequest request, string token);
    }
}
