using Domain;

namespace Infrastruct;

public class WeixinRepository : BaseRepository<Weixin>, IWeixinRepository
{
    public WeixinRepository(TeslaContext context) : base(context)
    {
    } 
}