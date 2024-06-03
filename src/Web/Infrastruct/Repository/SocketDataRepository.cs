using Domain;

namespace Infrastruct;

public class SocketDataRepository : BaseRepository<SocketData>, ISocketDataRepository
{
    public SocketDataRepository(TeslaContext context) : base(context)
    {
    } 
}