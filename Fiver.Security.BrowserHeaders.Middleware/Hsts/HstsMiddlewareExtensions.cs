using Microsoft.AspNetCore.Builder;
using System;

namespace Fiver.Security.BrowserHeaders.Middleware.Hsts
{
    public static class HstsMiddlewareExtensions
    {
        public static IApplicationBuilder UseHsts(
            this IApplicationBuilder app, Action<HstsOptionsBuilder> builder)
        {
            var newBuilder = new HstsOptionsBuilder();
            builder(newBuilder);

            var options = newBuilder.Build();
            return app.UseMiddleware<HstsMiddleware>(options);
        }
    }
}
