namespace Domain;

public class Token
{
    public int UserId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int ExpiresIn { get; set; }
}
public interface ITokenRepository : IRepository<Token>
{
    Task<Token?> GetByAccessToken(string token);
}