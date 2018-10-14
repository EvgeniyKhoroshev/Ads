using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Data.Repositories
{
    public class AdvertInfoRepository : IAdvertInfoRepository<AdvertsInfo, int>
    {
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
            return (new AdvertsInfo
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
    }
}