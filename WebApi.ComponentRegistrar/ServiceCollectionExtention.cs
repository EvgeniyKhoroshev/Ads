using Ads.Common;
using AppServices.ServiceInterfaces;
using AppServices.Services;
using Domain;
using Domain.Data.Repositories;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.ComponentRegistrar
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AdsDBContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<AdsDBContext>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IAdvertRepository, AdvertRepository>();
            services.AddTransient<IAdvertService, AdvertService>();
            services.AddTransient<IAdvertInfoRepository<AdvertsInfo, int>, AdvertInfoRepository>();
            services.AddTransient<IInfoService, InfoService>();

            AutoMapperConfig.Initialize();

            return services;
        }
    }
}
