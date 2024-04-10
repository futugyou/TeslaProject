

using TeslaApi.Contract.Vehicle.Miscellaneous;

public interface IVehicleMiscellaneous
{
    Task<ReleaseNotesResponse> ReleaseNote(string vehicle_id, string token);
}