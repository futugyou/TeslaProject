
using Domain;

namespace Infrastruct;

public class ChargesDetailRepository : BaseRepository<ChargesDetail>, IChargesDetailRepository
{
    public ChargesDetailRepository(UserContext context) : base(context)
    {
    } 
}