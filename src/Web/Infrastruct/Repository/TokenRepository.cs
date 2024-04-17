using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastruct;

public class TokenRepository : BaseRepository<Token>, ITokenRepository
{
    public TokenRepository(TeslaContext context) : base(context)
    {
    }

    public Task<Token?> GetByAccessToken(string token)
    {
        return GetAll().FirstOrDefaultAsync(p => p.AccessToken == token);
    }
}