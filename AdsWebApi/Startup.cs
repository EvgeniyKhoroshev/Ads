using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.AddDependencyInjection(Configuration.GetConnectionString("DefaultConnection"));
            services.AddCors(o => o.AddPolicy("allow", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

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
            //container.Verify();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        //private void IntegrateSimpleInjector(IServiceCollection services)
        //{
        //    container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

        //    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //    services.AddSingleton<IControllerActivator>(
        //        new SimpleInjectorControllerActivator(container));


        //    services.EnableSimpleInjectorCrossWiring(container);
        //    services.UseSimpleInjectorAspNetRequestScoping(container);
        //}
        //private void InitializeContainer(IApplicationBuilder app)
        //{
        //    // Allow Simple Injector to resolve services from ASP.NET Core.
        //    container.AutoCrossWireAspNetComponents(app);
        //}
    }
}
