using Microsoft.AspNetCore.Builder;
using System;

namespace Fiver.Security.BrowserHeaders.Middleware.Csp
{
    public static class CspMiddlewareExtensions
    {
        public static IApplicationBuilder UseCsp(
            this IApplicationBuilder app, Action<CspOptionsBuilder> builder)
        {
            var newBuilder = new CspOptionsBuilder();
            builder(newBuilder);

            var options = newBuilder.Build();
            return app.UseMiddleware<CspMiddleware>(options);
        }
    }
}
