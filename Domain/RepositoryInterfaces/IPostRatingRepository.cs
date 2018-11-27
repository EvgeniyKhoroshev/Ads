using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IPostRatingRepository
    {
        /// <summary>
        /// Устанавливает рейтинг к посту.
        /// </summary>
        /// <param name="ratingDto"></param>
        /// <returns>Возвращает true, если операция прошла успешно.</returns>
        Task<bool> SetRatingToPostAsync(PostRating rating);
    }
}
