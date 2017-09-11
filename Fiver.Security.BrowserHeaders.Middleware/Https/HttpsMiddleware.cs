using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Fiver.Security.BrowserHeaders.Middleware.Https
{
    public class HttpsMiddleware
    {
        private readonly RequestDelegate next;

        public HttpsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string location = 
                $"https://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
                
            if (context.Request.IsHttps)
                await this.next(context);
            else
                context.Response.Redirect(location: location, permanent: true);
        }
    }
}
