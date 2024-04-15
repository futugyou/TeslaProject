
using Domain;

namespace Infrastruct;

public class GeofenceRepository : BaseRepository<Geofence>, IGeofenceRepository
{
    public GeofenceRepository(UserContext context) : base(context)
    {
    } 
}