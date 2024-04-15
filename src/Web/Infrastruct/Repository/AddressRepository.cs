
using Domain;

namespace Infrastruct;

public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    public AddressRepository(UserContext context) : base(context)
    {
    } 
}