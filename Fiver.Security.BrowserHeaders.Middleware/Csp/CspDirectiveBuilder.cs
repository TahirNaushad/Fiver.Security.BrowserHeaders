using System.Collections.Generic;

namespace Fiver.Security.BrowserHeaders.Middleware.Csp
{
    public sealed class CspDirectiveBuilder
    {
        internal CspDirectiveBuilder() { }

        internal List<string> Sources { get; set; } = new List<string>();

        public CspDirectiveBuilder Allow(string source)
        {
            this.Sources.Add(source);
            return this;
        }
    }
}
