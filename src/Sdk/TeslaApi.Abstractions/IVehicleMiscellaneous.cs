using TeslaApi.Contract.Vehicle.Miscellaneous;

namespace TeslaApi.Abstractions;

public interface IVehicleMiscellaneous
{
    Task<ReleaseNotesResponse> ReleaseNote(string vehicle_id, string token);
}