using Fiver.Security.BrowserHeaders.Middleware.Common;

namespace Fiver.Security.BrowserHeaders.Middleware.Hsts
{
    public sealed class HstsOptionsBuilder
    {
        private readonly HstsOptions options = new HstsOptions();

        internal HstsOptionsBuilder()
        {
        }

        public HstsOptionsBuilder SetMaxAge(MaxAge maxAge)
        {
            this.options.MaxAge = maxAge;
            return this;
        }

        public HstsOptionsBuilder IncludePreload()
        {
            this.options.Preload = true;
            return this;
        }

        public HstsOptionsBuilder IncludeSubdomains()
        {
            this.options.Subdomains = true;
            return this;
        }

        internal HstsOptions Build()
        {
            return this.options;
        }
    }
}
