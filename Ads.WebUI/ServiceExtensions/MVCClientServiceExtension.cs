﻿using Ads.CoreService.Contracts.Dto;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Clients;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces;
using Ads.MVCClientApplication.Components.ApiRequests;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.AdvertRequests;
using Ads.MVCClientApplication.Models;
using Authentication.AppServices.CookieAuthentication;
using Authentication.AppServices.JwtAuthentication;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Ads.MVCClientApplication.Components.ApiClients.Interfaces;
using Ads.MVCClientApplication.Components.ApiClients.Clients;

namespace Ads.MVCClientApplication.ServiceExtensions
{
    public static class MVCClientServiceExtension
    {
        /// <summary>
        /// Регистрация сервисов предназначенных для взаимодействия клиента с API /
        /// Registration of services intended for client interaction with API
        /// </summary>
        #region Регистрация сервисов предназначенных для взаимодействия с API
        public static IServiceCollection ClientRequestsRegistration(this IServiceCollection services)
        {
            services.AddTransient<IApiAdvertClient, ApiAdvertClient>();
            services.AddTransient<IApiCommentsClient, ApiCommentsClient>();
            services.AddTransient<IApiUserClient, ApiUserClient>();
            services.AddTransient<IApiInfoClient, ApiInfoClient>();
            
            services.AddTransient<ApiClient>();
            return services;
        } 
        #endregion
        /// <summary>
        /// Регистрация сервисов, необходимых для Jwt аутентификации /
        /// Jwt auth service registration
        /// </summary>
        #region Регистрация сервисов для Jwt аутентификации
        public static IServiceCollection JwtAuthRegistration(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IJwtBasedCookieAuthenticationService, JwtBasedCookieAuthenticationService>();
            return services;
        } 
        #endregion
        public static IServiceCollection ServiceCollectionExtension(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            return services;
        }
        /// <summary>
        /// Инициализатор автомапера для клиента / 
        /// Automapper initializer for a client app
        /// </summary>
        public static void AutoMapperInitialize(this IServiceCollection services) => Mapper.Initialize(cfg =>
        {
            cfg.CreateMap<AdvertDto, AdsVMIndex>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            cfg.CreateMap<AdsVMIndex, AdvertDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            cfg.CreateMap<AdvertDto, AdsVMDetails>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            cfg.CreateMap<AdsVMDetails, AdvertDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            cfg.CreateMap<ManageVM, UserInfoDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            cfg.CreateMap<UserInfoDto, ManageVM>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        });
    }

}
