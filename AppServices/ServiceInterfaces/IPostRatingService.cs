
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
        /// <summary>
        /// Получение списка оцененных постов пользователя <paramref name="userId"/>, которые находятся в объявлении <paramref name="advertId"/>
        /// </summary>
        /// <param name="userId">Id текущего пользователя</param>
        /// <param name="advertId">Id объявления</param>
        /// <returns>Список оценок постов.</returns>
        Task<RatingDto[]> GetCurrentUserRatesAsync(int userId, int advertId);
        /// <summary>
        /// Получает значение рейтинга комментария
        /// </summary>
        /// <param name="advertId"></param>
        /// <returns></returns>
        Task<int> GetPostRatingAsync(int postId);
    }
}
