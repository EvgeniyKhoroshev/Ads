using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Data.Repositories
{
    public class AdvertRepository : Base.BaseRepository<Advert, int>, IAdvertRepository
    {
        /// <summary>
        /// Переменная контекста базы данных // 
        /// Variable of database context
        /// </summary>
        readonly AdsDBContext _dbContext;
        public AdvertRepository(AdsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Получение объявления по Id // 
        /// Getting an advert by Id
        /// </summary>
        /// <param name="id">Идентификатор объявления / Id of advert</param>
        /// <returns>Возвращает объявление / Returns advert</returns>
        public override async Task<Advert> Get(int id)
        {
            return await _dbContext
                                .Adverts
                                .FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// Сохраняет изменения или создает новый элемент, если такого не существует // 
        /// Save item or create if not exists
        /// </summary>
        /// <returns>Возвращает сохраненный или созданый элемент / 
        /// Returns the created or saved item</returns>
        public override async Task<Advert> SaveOrUpdate(Advert entity)
        {
            if (!_dbContext.Adverts.ContainsAsync(entity).Result)
            {
                _dbContext.Adverts.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            _dbContext.Adverts.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        /// <summary>
        /// Возвращает список существующих объявлений не включая дочерние // 
        /// Returns all adverts excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает список объявлений / 
        /// Getting the adverts list</returns>
        public override async Task<IList<Advert>> GetAllWithoutIncludes()
        {

            return await _dbContext.Adverts.ToListAsync();
        }


        /// <summary>
        /// Удаление объявления по Id // 
        /// Deleting an entity by Id
        /// </summary>
        /// <param name="id">Идентификатор объявления / Id of entity</param>
        public override async Task Delete(int Id)
        {
            var adv = await _dbContext.Adverts.FindAsync(Id);
            _dbContext.Adverts.Remove(adv);
            await _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Возвращает список существующих объявлений включая дочерние // 
        /// Returns all adverts including subsidiaries
        /// </summary>
        /// <returns>Возвращает список существующих объявлений включая дочерние / 
        /// Returns all adverts including subsidiaries</returns>
        public override async Task<IList<Advert>> GetAllWithIncludes()
        {

            return await _dbContext.Adverts
                            .Include(t => t.Status)
                            .Include(t => t.Category)
                            .Include(c => c.Type)
                            .Include(d => d.City)
                            .ToListAsync();
        }


        /// <summary>
        /// Возвращает существующиq элемент включая дочерние // 
        /// Returns item including subsidiaries
        /// </summary>
        /// <returns>Возвращает существующий элемент включая дочерние / 
        /// Returns item including subsidiaries</returns>
        public override async Task<Advert> GetWithIncludes(int Id)
        {
            try
            {
                var adv = await _dbContext.Adverts.FirstOrDefaultAsync(x => x.Id == Id);
                if (adv != null)
                    return await _dbContext.Adverts
                                            .Include(t => t.Type)
                                            .Include(t => t.Category)
                                            .Include(t => t.City)
                                            .FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception) { }
            return null;
        }
        /// <summary>
        /// Возвращает существующий элемент не включая дочерние // 
        /// Returns item excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает элемент / 
        /// Getting the adverts list</returns>
        public override async Task<Advert> GetWithoutIncludes(int Id)
        {
            try
            {
                var adv = await _dbContext.Adverts.FirstOrDefaultAsync(x => x.Id == Id);
                if (adv != null)
                    return await _dbContext
                    .Adverts
                    .FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception) { }
            return null;
        }

        /// <summary>
        /// Функция для получения списка базовой информации об объявлениях
        /// The function to getting a list of a base adverts information 
        /// </summary>
        /// <returns> Общую информацию для заполнения(отображения) объявлений / 
        /// Base infromation to entity filling </returns>
        public override Task<Advert> GetInfo()
        {
            throw new NotImplementedException();

        }
    }

}