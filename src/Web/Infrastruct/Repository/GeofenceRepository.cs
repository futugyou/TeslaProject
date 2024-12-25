namespace Infrastruct;

public class GeofenceRepository : BaseRepository<Geofence>, IGeofenceRepository
{
    public GeofenceRepository(TeslaContext context) : base(context)
    {
    } 
}