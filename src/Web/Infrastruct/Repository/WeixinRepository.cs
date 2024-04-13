using Domain;

namespace Infrastruct;

public class WeixinRepository : BaseRepository<Weixin>, IWeixinRepository
{
    public WeixinRepository(UserContext context) : base(context)
    {
    } 
}