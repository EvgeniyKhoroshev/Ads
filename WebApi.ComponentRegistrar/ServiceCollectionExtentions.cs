using Ads.Common;
using AppServices.ServiceInterfaces;
using AppServices.Services;
using Authentication.AppServices.JwtAuthentication;
using Domain;
using Domain.Data.Repositories;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApi.ComponentRegistrar
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AdsDBContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<User, IdentityRole<int>>(
               options =>
               {
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequiredLength = 6;
                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                   options.Lockout.MaxFailedAccessAttempts = 5;

                   // INITIALIZE TOKEN PROVIDER DESCRIPTOR FOR PRE-RESET PASSWORD'S TIME SPAN
                   options.Tokens.ProviderMap.Add("Default", new TokenProviderDescriptor(typeof(TokenProviderDescriptor)));
               })
                .AddEntityFrameworkStores<AdsDBContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IAdvertRepository, AdvertRepository>();
            services.AddTransient<IAdvertService, AdvertService>();
            services.AddTransient<IAdvertInfoRepository<AdvertsInfo, int>, AdvertInfoRepository>();
            services.AddTransient<IInfoService, InfoService>();
            
            // Jwt services
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IJwtAuthenticationService, JwtAuthenticationService>();

            AutoMapperConfig.Initialize();

            return services;
        }
    }
}
