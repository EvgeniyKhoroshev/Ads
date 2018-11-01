using Ads.Contracts.Dto;
using Ads.WebUI.Components.ApiRequests;
using Ads.WebUI.Controllers.Components.ApiClients.AdvertRequests;
using Ads.WebUI.Controllers.Components.ApiClients.Interfaces;
using Ads.WebUI.Models;
using Authentication.AppServices.CookieAuthentication;
using Authentication.AppServices.JwtAuthentication;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Ads.WebUI.ServiceExtensions
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
        });
    }

}
