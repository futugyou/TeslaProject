using System.IdentityModel.Tokens.Jwt;

namespace TeslaApi.Contract;

public class TokenParse
{
    public static DateTime UnixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public static TokenLocal CheckTokenLocal(string accessToken)
    {
        // Decode the access token
        var handler = new JwtSecurityTokenHandler();

        try
        {
            if (handler.ReadToken(accessToken) is not JwtSecurityToken jsonToken)
            {
                return TokenLocal.Unkown;
            }
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddSeconds(1111).ToLocalTime();

            var cn = jsonToken.Claims.Where(p => p.Type == "iss" && p.Value.StartsWith("https://auth.tesla.cn"));
            if (cn != null && cn.Any())
            {
                return TokenLocal.China;
            }
        }
        catch
        {
            return TokenLocal.Unkown;
        }

        return TokenLocal.Global;
    }

}

public enum TokenLocal
{
    Global,
    China,
    Unkown,
}

public class TokenInfo
{
    public string Subject { get; }
    public string Issue { get; }
    public string AuthorizedParty { get; }
    public DateTime ExpirationTime { get; }
    public DateTime IssuedTime { get; }
    public TokenLocal Locale { get; }

    public TokenInfo(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        try
        {
            if (handler.ReadToken(token) is not JwtSecurityToken jsonToken)
            {
                return;
            }

            Subject = jsonToken.Subject;
            Issue = jsonToken.Issuer;
            IssuedTime = jsonToken.IssuedAt;

            foreach (var claim in jsonToken.Claims)
            {
                if (claim.Type == "azp")
                {
                    AuthorizedParty = claim.Value;
                }
                if (claim.Type == "exp")
                {
                    ExpirationTime = TokenParse.UnixStart.AddSeconds(long.Parse(claim.Value)).ToUniversalTime();
                }
                if (claim.Type == "ou_code")
                {
                    Locale = claim.Value == "CN" ? TokenLocal.China : TokenLocal.Global;
                }
            }
        }
        catch
        {

        }
    }

    public bool IsTokenExpiration() => ExpirationTime.CompareTo(DateTime.UtcNow.AddSeconds(-5)) < 0;
}