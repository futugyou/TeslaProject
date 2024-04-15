

using Domain;

namespace Infrastruct;

public class ChargesRepository : BaseRepository<Charges>, IChargesRepository
{
    public ChargesRepository(UserContext context) : base(context)
    {
    } 
}