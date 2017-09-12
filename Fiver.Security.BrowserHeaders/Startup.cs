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
            services.AddMvc();
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new RequireHttpsAttribute());
            //});
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            //app.UseHtps();

            //app.UseRewriter(new RewriteOptions()
            //                    .AddRedirectToHttps(302, 44379));

            //app.UseHsts(builder =>
            //{
            //    builder.SetMaxAge(MaxAge.FromDays(365))
            //           .IncludePreload()
            //           .IncludeSubdomains();
            //});

            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add(
            //        "Content-Security-Policy",
            //        "script-src 'self'; " +
            //        "style-src 'self'; " +
            //        "img-src 'self'");

            //    await next();
            //});

            app.UseCsp(builder =>
            {
                builder.Defaults
                       .AllowSelf();

                builder.Scripts
                       .AllowSelf()
                       .Allow("https://ajax.aspnetcdn.com");

                builder.Styles
                       .AllowSelf()
                       .Allow("https://ajax.aspnetcdn.com");

                builder.Fonts
                       .AllowSelf()
                       .Allow("https://ajax.aspnetcdn.com");

                builder.Images
                       .AllowSelf()
                       .Allow("https://media-www-asp.azureedge.net/");
            });

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
