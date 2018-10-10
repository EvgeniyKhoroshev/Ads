using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Data.Repositories
{
    public class AdvertInfoRepository : IAdvertInfoRepository
    {
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AdvertsInfo>> GetAllWithIncludes()
        {
            throw new NotImplementedException();
        }
        readonly AdsDBContext _dbContext;
        public AdvertInfoRepository(AdsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Функция для получения списка базовой информации об объявлениях
        /// The function to getting a list of a base AdvertsInfos information 
        /// </summary>
        /// <returns> Общую информацию для заполнения(отображения) объявлений / 
        /// Base infromation to entity filling </returns>
        public async Task<AdvertsInfo> GetInfo()
        {
            return  (new AdvertsInfo
            {
                Categories = await _dbContext
                                .Categories.ToListAsync(),
                Cities = await _dbContext.Cities
                                .ToListAsync(),
                Regions = await _dbContext.Regions
                                .ToListAsync(),
                Statuses = await _dbContext
                                .Statuses.ToListAsync(),
                Types = await _dbContext.AdvertTypes
                                .ToListAsync()
            });

        }

        public Task<AdvertsInfo> GetWithIncludes(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AdvertsInfo>> GetWithoutIncludes()
        {
            throw new NotImplementedException();
        }

        public Task<AdvertsInfo> GetWithoutIncludes(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AdvertsInfo> SaveOrUpdate(AdvertsInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AdvertsInfo>> GetAllWithoutIncludes()
        {
            throw new NotImplementedException();
        }
    }

}