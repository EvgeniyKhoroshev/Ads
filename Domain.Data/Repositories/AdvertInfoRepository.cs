using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<AdvertsInfo> GetAllAsync()
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
        /// <summary>
        /// Получение категорий из БД //
        /// Getting the categories from database
        /// </summary>
        /// <returns>Массив категорий /
        /// Categories array</returns>
        public async Task<Category[]> GetCategoriesAsync()
        {
            Category[] result;
            try
            {
                result = await _dbContext
                    .Categories
                    .ToArrayAsync();

                return result;
            }
            catch (Exception ex)
            {
                string error = "При попытке получить массив категорий из БД произошла ошибка. " + ex.Message;
                throw new DbUpdateException(string.Join(Environment.NewLine, error), ex);
            }
        }

        /// <summary>
        /// Получение городов из БД //
        /// Getting the cities from database
        /// </summary>
        /// <returns>Массив городов /
        /// Cities array</returns>
        public async Task<City[]> GetCitiesAsync(int? regionId)
        {
            City[] result;
            try
            {
                if (regionId != null)
                {
                    result = await _dbContext.Set<City>()
                        .Where(q => q.RegionId == regionId)
                        .ToArrayAsync();
                    return result;
                }
                else
                    return await _dbContext.Set<City>()
                        .ToArrayAsync();
            }
            catch (Exception ex)
            {
                string error = "При попытке получить массив городов из БД произошла ошибка. " + ex.Message;
                throw new DbUpdateException(string.Join(Environment.NewLine, error), ex);
            }
        }

        /// <summary>
        /// Получение городов из БД //
        /// Getting the cities from database
        /// </summary>
        /// <returns>Массив городов /
        /// Regions array</returns>

        public async Task<Region[]> GetRegionsAsync()
        {
            Region[] result;
            try
            {
                result = await _dbContext
                    .Regions
                    .ToArrayAsync();

                return result;
            }
            catch (Exception ex)
            {
                string error = "При попытке получить массив регионов из БД произошла ошибка. " + ex.Message;
                throw new DbUpdateException(string.Join(Environment.NewLine, error), ex);
            }
        }
        /// <summary>
        /// Получение массива статусов из БД //
        /// Getting the statuses array from database
        /// </summary>
        /// <returns>Массив статусов /
        /// Statuses array</returns>
        public async Task<Status[]> GetStatussesAsync()
        {
            Status[] result;
            try
            {
                result = await _dbContext
                    .Statuses
                    .ToArrayAsync();

                return result;
            }
            catch (Exception ex)
            {
                string error = "При попытке получить массив статусов из БД произошла ошибка. " + ex.Message;
                throw new DbUpdateException(string.Join(Environment.NewLine, error), ex);
            }
        }

        /// <summary>
        /// Получение массива типов объявления из БД //
        /// Getting the advert types array from database
        /// </summary>
        /// <returns>Массив типов объявления/
        /// Advert types array</returns>`
        public async Task<AdvertType[]> GetTypesAsync()
        {
            AdvertType[] result;
            try
            {
                result = await _dbContext
                    .AdvertTypes
                    .ToArrayAsync();

                return result;
            }
            catch (Exception ex)
            {
                string error = "При попытке получить массив типов объявлений из БД произошла ошибка. " + ex.Message;
                throw new DbUpdateException(string.Join(Environment.NewLine, error), ex);
            }
        }
    }
}