
using Domain;

namespace Infrastruct;

public class ChargesDetailRepository : BaseRepository<ChargesDetail>, IChargesDetailRepository
{
    public ChargesDetailRepository(TeslaContext context) : base(context)
    {
    } 
}