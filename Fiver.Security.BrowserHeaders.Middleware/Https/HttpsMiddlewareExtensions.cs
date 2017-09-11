using Microsoft.AspNetCore.Builder;

namespace Fiver.Security.BrowserHeaders.Middleware.Https
{
    public static class HttpsMiddlewareExtensions
    {
        public static IApplicationBuilder UseHtps(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<HttpsMiddleware>();
        }
    }
}
