using Domain;

namespace Infrastruct;

public class TokenRepository : BaseRepository<Token>, ITokenRepository
{
    public TokenRepository(TeslaContext context) : base(context)
    {
    } 
}