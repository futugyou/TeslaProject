using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Vehicle.State.VehicleState
{
    public enum CenterDisplayState
    {
        Off = 0,
        StandbyOrCampMode = 2,
        ChargingScreen = 3,
        Unknow = 4,
        BigChargingScreen = 5,
        ReadyToUnlock = 6,
        SentryMode = 7,
        DogMode = 8,
        Media = 9,
    }
}
