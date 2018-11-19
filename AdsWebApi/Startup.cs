using AdsWebApi.Security;
using Authentication.Contracts.JwtAuthentication.Options;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Profiling.Storage;
using System;
using WebApi.ComponentRegistrar;


namespace AdsWebApi
{
    public class Startup
    {
        //private Container container = new Container();
        public Startup(IConfiguration configuration)
        {
            //AutoMapperConfig.Initialize();
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
            services.AddDependencyInjection(Configuration.GetConnectionString("DefaultConnection"));
            var jwtOptions = new JwtServerAuthenticationOptions();
            Configuration.GetSection("JwtAuthentication").Bind(jwtOptions);
            services.Configure<JwtServerAuthenticationOptions>(Configuration.GetSection("JwtAuthentication"));
            services.Configure<JwtBaseAuthenticationOptions>(Configuration.GetSection("JwtAuthentication"));
            services.JWTSecurityExtention(jwtOptions);
            services.AddCors(o => o.AddPolicy("allow", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //InitializeContainer(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMiniProfiler();

            app.UseMvc();
        }
    }
}
