using Domain;

namespace Extensions;
public class WeixinRequestMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, IWeixinRepository repository)
    {
        string openid = context.Request.Headers["X-WX-OPENID"];
        // Eventually, this project will run on WeChat cloud hosting, in order to simplify weixin auth flow.
        if (!string.IsNullOrWhiteSpace(openid))
        {
            var wei = await repository.GetById(openid);
            if (wei != null)
            {
                string appid = context.Request.Headers["X-WX-APPID"];
                string unid = context.Request.Headers["X-WX-UNIONID"];
                string fromopenid = context.Request.Headers["X-WX-FROM-OPENID"];
                string fromappid = context.Request.Headers["X-WX-FROM-APPID"];
                string fromunid = context.Request.Headers["X-WX-FROM-UNIONID"];
                string env = context.Request.Headers["X-WX-ENV"];
                string source = context.Request.Headers["X-WX-SOURCE"];
                string forwarded = context.Request.Headers["X-Forwarded-For"];

                // TODO: do some other work use this data, maybe refresh other platform(tesla) token.

                var weixin = new Weixin
                {
                    Openid = openid,
                    AppId = appid ?? "",
                    UnionId = unid ?? "",
                    FromAppId = fromappid ?? "",
                    FromOpenid = fromopenid ?? "",
                    FromUnionId = fromunid ?? "",
                    CouldEnv = env ?? "",
                    Source = source ?? "",
                    Forwarded = forwarded ?? "",
                };

                await repository.Update(weixin);
            }
        }

        await _next(context);
    }
}