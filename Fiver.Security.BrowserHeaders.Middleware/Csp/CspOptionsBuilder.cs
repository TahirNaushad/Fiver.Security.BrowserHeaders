namespace Fiver.Security.BrowserHeaders.Middleware.Csp
{
    public sealed class CspOptionsBuilder
    {
        private readonly CspOptions options = new CspOptions();
        
        internal CspOptionsBuilder()
        {
        }

        public CspDirectiveBuilder Defaults { get; set; } = new CspDirectiveBuilder();
        public CspDirectiveBuilder Scripts { get; set; } = new CspDirectiveBuilder();
        public CspDirectiveBuilder Styles { get; set; } = new CspDirectiveBuilder();

        internal CspOptions Build()
        {
            this.options.Defaults = this.Defaults.Sources;
            this.options.Scripts = this.Scripts.Sources;
            this.options.Styles = this.Styles.Sources;
            return this.options;
        }
    }
}
