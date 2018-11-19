using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ads.MVCClientApplication.ServiceExtensions;
using Authentication.Contracts.JwtAuthentication.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Ads.Shared.Contracts;
using Ads.Shared.Contracts.Areas;
using StackExchange.Profiling.Storage;
using System;

namespace Ads.MVCClientApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);
                options.TrackConnectionOpenClose = true;

            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            // Getting the Jwt auth options
            services.Configure<JwtClientAuthenticationOptions>(Configuration.GetSection("JwtAuthentication"));


            services.Configure<ApiBaseOption>(Configuration.GetSection("ApiBaseOptions"));
            services.Configure<ApiAdvertsArea>(Configuration.GetSection("ApiAdvertsArea"));
            services.Configure<ApiCommentsArea>(Configuration.GetSection("ApiCommentsArea"));
            services.Configure<ApiUsersArea>(Configuration.GetSection("ApiUsersArea"));

            services.Configure<JwtBaseAuthenticationOptions>(Configuration.GetSection("JwtAuthentication"));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>    {
                    o.LoginPath = "/authentication/signin";
                });
            // Custom service collection extensions
            services.ServiceCollectionExtension();
            services.AutoMapperInitialize();
            services.ClientRequestsRegistration();
            services.JwtAuthRegistration();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMiniProfiler();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Adverts}/{action=Index}/{page?}");
            });
        }
    }
}
