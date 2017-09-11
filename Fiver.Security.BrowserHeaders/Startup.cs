using Fiver.Security.BrowserHeaders.Middleware.Common;
using Fiver.Security.BrowserHeaders.Middleware.Csp;
using Fiver.Security.BrowserHeaders.Middleware.Hsts;
using Fiver.Security.BrowserHeaders.Middleware.Https;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;

namespace Fiver.Security.BrowserHeaders
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            //app.UseHtps();

            //app.UseRewriter(new RewriteOptions()
            //                    .AddRedirectToHttps(302, 44379));

            app.UseHsts(builder =>
            {
                builder.SetMaxAge(MaxAge.FromDays(365))
                       .IncludePreload()
                       .IncludeSubdomains();
            });

            app.UseCsp(builder =>
            {
                builder.Defaults
                       .Allow("'self'");

                builder.Scripts
                       .Allow("'self'")
                       .Allow("https://ajax.aspnetcdn.com");

                builder.Styles
                       .Allow("'self'");
            });

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
