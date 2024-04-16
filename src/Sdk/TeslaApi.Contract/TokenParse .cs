using System.IdentityModel.Tokens.Jwt;

namespace TeslaApi.Contract;

public class TokenParse
{
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