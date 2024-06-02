using TeslaApi.Contract.Vehicle.Miscellaneous;
using Refit;

namespace TeslaApi.SDK;

public interface IVehicleMiscellaneous : IVehicleRefit
{
    [Get("/api/1/vehicles/{vehicle_id}/release_notes")]
    Task<ReleaseNotesResponse> ReleaseNote(string vehicle_id, [Authorize("Bearer")] string token);
}