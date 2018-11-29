using Domain.Data.Repositories.Base;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Data.Repositories
{
    public class ImageRepository : BaseRepository<Image,int>, IImageRepository
    {
        public ImageRepository(AdsDBContext dbContext) : base(dbContext) { }
        /// <inheritdoc />
        public async Task<bool> DeleteAdvertImages(int advertId)
        {
            try
            {
                var images = await _dbContext.Set<Image>()
                    .Where(i => i.AdvertId == advertId)
                    .ToArrayAsync();
                if (images.Length == 0)
                    return true;
                foreach (var i in images)
                {
                    _dbContext.Set<Image>().Remove(i);
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("При попытке удалить фотографии объявления №" +
                    advertId + " произошла ошибка. " + ex.Message);
            }
        }
        /// <inheritdoc />
        public async Task<Image[]> GetAdvertImages(int advertId)
        {
            try
            {
                return await _dbContext.Images.Where(t => t.AdvertId == advertId).ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("При попытке получить фотографии объявления №" +
                    advertId + " произошла ошибка. " + ex.Message);
            }
        }
    }
}
