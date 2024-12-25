namespace Infrastruct;

public class VehicleRepository(TeslaContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
    public Task<Vehicle?> GetByVid(long vid)
    {
         return GetAll().FirstOrDefaultAsync(p => p.Vid == vid);
    }

    public Task<Vehicle?> GetByVin(string vin)
    {
        return GetAll().FirstOrDefaultAsync(p => p.Vin == vin);
    }
}