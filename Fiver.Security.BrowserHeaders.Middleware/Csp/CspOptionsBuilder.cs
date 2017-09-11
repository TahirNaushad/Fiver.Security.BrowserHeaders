namespace Fiver.Security.BrowserHeaders.Middleware.Csp
{
    public sealed class CspOptionsBuilder
    {
        private readonly CspOptions options = new CspOptions();

        internal CspOptionsBuilder()
        {
        }

        

        internal CspOptions Build()
        {
            return this.options;
        }
    }
}
