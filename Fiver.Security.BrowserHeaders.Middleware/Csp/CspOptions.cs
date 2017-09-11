using System.Collections.Generic;

namespace Fiver.Security.BrowserHeaders.Middleware.Csp
{
    public sealed class CspOptions
    {
        public List<string> Defaults { get; set; } = new List<string>();
        public List<string> Scripts { get; set; } = new List<string>();
        public List<string> Styles { get; set; } = new List<string>();
    }
}
