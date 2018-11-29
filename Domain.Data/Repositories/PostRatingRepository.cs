using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <inheritdoc />
        public async Task<int> GetPostRatingAsync(int postId)
        {
            var positive = await _dbContext
                .PostRatings
                .Where(t =>t.PostId==postId)
                .Where(r => r.IsRated)
                .CountAsync();
            var negative = await _dbContext
                .PostRatings
                .Where(t =>t.PostId==postId)
                .Where(r => !r.IsRated)
                .CountAsync();
            return positive - negative;
        }

        /// <inheritdoc />
        public async Task<PostRating[]> GetUserRatesAsync(int userId, int advertId)
        {
            try
            {
                var postRatingsList = await _dbContext
                    .PostRatings
                    .Where(s => s.UserId == userId)
                    .Join(_dbContext.Comments, p => p.PostId, z => z.Id, (p, z) => new { PostRating = p, Comment = z })
                    .Where(d => d.Comment.AdvertId == advertId)
                    .Select(z =>z.PostRating)
                    .ToArrayAsync();
                return postRatingsList;
            }
            catch (Exception ex)
            {
                string error = "При попытке установить информацию о рейтинге из БД произошла ошибка. " + ex.Message;
                throw new NullReferenceException(string.Join(Environment.NewLine, error), ex);
            }
        }

        /// <inheritdoc />
        public async Task<bool> SetRatingToPostAsync(PostRating rating)
        {
            try
            {
                var ratingValue = await _dbContext
                    .PostRatings
                    .AsNoTracking()
                    .Where(t=> t.UserId == rating.UserId)
                    .Where(g => g.PostId == rating.PostId)
                    .FirstOrDefaultAsync();
                if (ratingValue != null)
                    if (rating.IsRated == ratingValue.IsRated)
                    {
                        _dbContext.PostRatings.Remove(ratingValue);
                        await _dbContext.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        _dbContext.PostRatings.Update(rating);
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
                string error = "При попытке установить информацию о рейтинге из БД произошла ошибка. " + ex.Message;
                throw new NullReferenceException(string.Join(Environment.NewLine, error), ex);
            }
        }

    }
}
