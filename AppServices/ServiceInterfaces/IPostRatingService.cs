
using Ads.CoreService.Contracts.Dto;
using System.Threading.Tasks;

namespace Ads.CoreService.AppServices.ServiceInterfaces
{
    public interface IPostRatingService
    {
        /// <summary>
        /// Устанавливает рейтинг к посту.
        /// </summary>
        /// <param name="ratingDto"></param>
        /// <returns>Возвращает true, если операция прошла успешно.</returns>
        Task<bool> SetRatingToPostAsync(RatingDto rating);
    }
}
