using Ads.WebUI.Components.ApiRequests;
using Ads.WebUI.Controllers.Components.ApiRequests.AdvertRequests;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces;
using Authentication.AppServices.CookieAuthentication;
using Authentication.AppServices.JwtAuthentication;
using Microsoft.Extensions.DependencyInjection;

namespace Ads.WebUI.ServiceExtentions
{
    public static class WebUIServiceExtention
    {
        public static void APIRequestsRegistration(this IServiceCollection services)
        {
            services.AddTransient<IAdvertRequest, AdvertRequest>(); 
            services.AddTransient<ICommentRequest, CommentRequest>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IJwtBasedCookieAuthenticationService, JwtBasedCookieAuthenticationService>();

            services.AddTransient<APIRequests>();
        }
    }
}
