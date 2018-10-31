using Ads.Contracts.Dto;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers.Components.ApiRequests.Interfaces
{
    public interface IApiCommentsClient : IApiBaseClient<CommentDto, int>
    {
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
