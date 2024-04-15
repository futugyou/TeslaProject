
using Domain;

namespace Infrastruct;

public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(UserContext context) : base(context)
    {
    } 
}