﻿using AppServices.ServiceInterfaces;
using AppServices.Services;
using Domain;
using Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ads.WebUI.Controllers.Components
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AdsDBContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<AdsDBContext>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
