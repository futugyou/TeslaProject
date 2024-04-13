using Domain;

namespace Infrastruct;

public class TokenRepository : BaseRepository<Token>, ITokenRepository
{
    public TokenRepository(UserContext context) : base(context)
    {
    } 
}