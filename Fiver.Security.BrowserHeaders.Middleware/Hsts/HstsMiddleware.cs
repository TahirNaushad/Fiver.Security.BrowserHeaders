using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Fiver.Security.BrowserHeaders.Middleware.Hsts
{
    public sealed class HstsMiddleware
    {
        private const string HEADER = "Strict-Transport-Security";
        private readonly RequestDelegate next;
        private readonly HstsOptions options;

        public HstsMiddleware(
            RequestDelegate next, HstsOptions options)
        {
            this.next = next;
            this.options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.IsHttps)
                context.Response.Headers.Add(HEADER, GetHeaderValue());
            
            await this.next(context);
        }

        private string GetHeaderValue()
        {
            var value = $"max-age={this.options.MaxAge.Value}";

            if (this.options.Subdomains)
                value += "; includeSubdomains";

            if (this.options.Preload)
                value += "; preload";

            return value;
        }
    }
}
