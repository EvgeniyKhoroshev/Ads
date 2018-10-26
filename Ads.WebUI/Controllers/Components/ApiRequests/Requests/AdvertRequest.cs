using Ads.Contracts.Dto;
using Ads.WebUI.Controllers.Components.ApiRequests.BaseRequest;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces;

namespace Ads.WebUI.Controllers.Components.ApiRequests.AdvertRequests
{
    public class AdvertRequest : BaseRequest<AdvertDto, int>,  IAdvertRequest
    {
        public AdvertRequest() : base("adverts") { }
    }
}
