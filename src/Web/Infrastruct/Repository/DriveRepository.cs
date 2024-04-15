
using Domain;

namespace Infrastruct;

public class DriveRepository : BaseRepository<Drive>, IDriveRepository
{
    public DriveRepository(TeslaContext context) : base(context)
    {
    } 
}