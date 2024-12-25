namespace Infrastruct;

public class VehicleMessageRepository : BaseRepository<VehicleMessage>, IVehicleMessageRepository
{
    public VehicleMessageRepository(TeslaContext context) : base(context)
    {
    } 
}