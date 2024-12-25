namespace Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseWeixinRequest(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<WeixinRequestMiddleware>();
    }
}
