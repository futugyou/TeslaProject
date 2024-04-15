

using Domain;

namespace Infrastruct;

public class ChargesRepository : BaseRepository<Charges>, IChargesRepository
{
    public ChargesRepository(TeslaContext context) : base(context)
    {
    } 
}