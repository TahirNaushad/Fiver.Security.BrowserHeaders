using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiver.Security.BrowserHeaders.Middleware.Csp
{
    public sealed class CspMiddleware
    {
        private const string HEADER = "Content-Security-Policy";
        private readonly RequestDelegate next;
        private readonly CspOptions options;

        public CspMiddleware(
            RequestDelegate next, CspOptions options)
        {
            this.next = next;
            this.options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(HEADER, GetHeaderValue());

            await this.next(context);
        }

        private string GetHeaderValue()
        {
            var value = "";

            value += GetDirective("default-src", this.options.Defaults);
            value += GetDirective("script-src", this.options.Scripts);
            value += GetDirective("style-src", this.options.Styles);
            
            return value;
        }

        private string GetDirective(string directive, List<string> sources)
            => sources.Count > 0 ? $"{directive} {string.Join(" ", sources)}; " : "";
    }
}
