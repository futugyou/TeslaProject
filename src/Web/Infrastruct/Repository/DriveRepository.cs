
using Domain;

namespace Infrastruct;

public class DriveRepository : BaseRepository<Drive>, IDriveRepository
{
    public DriveRepository(UserContext context) : base(context)
    {
    } 
}