using Ads.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using Ads.WebUI.Controllers.Components.ApiClients.Interfaces.Base;
using Ads.WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers.Components.ApiClients.Interfaces
{
    public interface IApiAdvertClient : IApiBaseClient<AdvertDto, int>
    {
        Task<PagedCollection<AdvertDto>> GetFiltredAsync(AdvertFilterDto filter);
        /// <summary>
        /// Получить список комментариев объявления с указанным <paramref name="advertId"/> /
        /// Get the comments list with the given <paramref name="advertId"/>
        /// </summary>
        /// <param name="advertId">Идентификатор объявления / 
        /// Advert Id</param>
        /// <returns>Список комментариев / 
        /// List of a comments</returns>
        Task<IList<CommentDto>> GetAdvertCommentsAsync(int advertId);
    }
}
