using Ads.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces.Base;
using Ads.WebUI.Models;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers.Components.ApiRequests.Interfaces
{
    public interface IApiAdvertClient : IApiBaseClient<AdvertDto, int>
    {
        Task<PagedCollection<AdvertDto>> GetFiltredAsync(AdvertFilterDto filter);
    }
}
