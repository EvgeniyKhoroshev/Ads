using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data.Repositories
{
    public class PostRatingRepository : IPostRatingRepository
    {
        protected readonly AdsDBContext _dbContext;
        public PostRatingRepository(AdsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        // <inheritdoc />
        public async Task<bool> SetRatingToPostAsync(PostRating rating)
        {
            try
            {
                var ratingValue = await _dbContext.PostRatings.FirstOrDefaultAsync(t => t.UserId == rating.UserId);
                if (ratingValue != null)
                    if (rating.IsRated == ratingValue.IsRated)
                    {
                        _dbContext.PostRatings.Remove(rating);
                        await _dbContext.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        _dbContext.PostRatings.Update(ratingValue);
                        await _dbContext.SaveChangesAsync();
                    }
                else
                {
                    await _dbContext.PostRatings.AddAsync(rating);
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                string error = "При попытке получить информацию о рейтинге из БД произошла ошибка. " + ex.Message;
                throw new NullReferenceException(string.Join(Environment.NewLine, error), ex);
            }
        }

    }
}
