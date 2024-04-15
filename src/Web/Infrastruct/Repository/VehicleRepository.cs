
using Domain;

namespace Infrastruct;

public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(TeslaContext context) : base(context)
    {
    } 
}