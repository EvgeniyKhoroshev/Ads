using Ads.WebUI.Components.ApiRequests;
using Ads.WebUI.Controllers.Components.ApiRequests.AdvertRequests;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ads.WebUI.ServiceExtentions
{
    public static class WebUIServiceExtention
    {
        public static void APIRequestsRegistration(this IServiceCollection services)
        {
            services.AddTransient<IAdvertRequest, AdvertRequest>(); 
            services.AddTransient<ICommentRequest, CommentRequest>(); 
            services.AddTransient<APIRequests>();
        }
    }
}
