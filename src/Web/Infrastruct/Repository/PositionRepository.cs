
using Domain;

namespace Infrastruct;

public class PositionRepository : BaseRepository<Position>, IPositionRepository
{
    public PositionRepository(TeslaContext context) : base(context)
    {
    } 
}