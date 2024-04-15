
using Domain;

namespace Infrastruct;

public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    public AddressRepository(TeslaContext context) : base(context)
    {
    } 
}