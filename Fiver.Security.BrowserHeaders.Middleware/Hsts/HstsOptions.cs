using Fiver.Security.BrowserHeaders.Middleware.Common;

namespace Fiver.Security.BrowserHeaders.Middleware.Hsts
{
    public sealed class HstsOptions
    {
        public MaxAge MaxAge { set; get; }
        public bool Subdomains { set;  get; }
        public bool Preload { set;  get; }
    }
}
