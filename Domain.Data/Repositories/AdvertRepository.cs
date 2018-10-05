using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
        public override Advert Get(int id)
        {
            Advert result = _dbContext
                                .Adverts
                                .FirstOrDefaultAsync(x => x.Id == id)
                                .Result;
            return result;
        }
        /// <summary>
        /// Сохраняет изменения или создает новый элемент, если такого не существует // 
        /// Save item or create if not exists
        /// </summary>
        /// <returns>Возвращает сохраненный или созданый элемент / 
        /// Returns the created or saved item</returns>
        public override Advert SaveOrUpdate(Advert entity)
        {
            if (!_dbContext.Adverts.ContainsAsync(entity).Result)
            {
                _dbContext.Adverts.Add(entity);
                _dbContext.SaveChangesAsync();
                return entity;
            }
            _dbContext.Adverts.Update(entity);
            _dbContext.SaveChangesAsync();
            return entity;

        }
        /// <summary>
        /// Возвращает список существующих объявлений не включая дочерние // 
        /// Returns all adverts excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает список объявлений / 
        /// Getting the adverts list</returns>
        public override IList<Advert> GetAllWithoutIncluding()
        {

            return _dbContext.Adverts.ToListAsync().Result;
        }


        /// <summary>
        /// Удаление объявления по Id // 
        /// Deleting an entity by Id
        /// </summary>
        /// <param name="id">Идентификатор объявления / Id of entity</param>
        public override void Delete(int Id)
        {

        }
        /// <summary>
        /// Возвращает список существующих объявлений включая дочерние // 
        /// Returns all adverts including subsidiaries
        /// </summary>
        /// <returns>Возвращает список существующих объявлений включая дочерние / 
        /// Returns all adverts including subsidiaries</returns>
        public override IList<Advert> GetAllWithIncludes()
        {
            return _dbContext.Adverts
                .Include(t => t.Status)
                .Include(t => t.Category)
                .Include(c => c.Type)
                .Include(d => d.City)
                .ToListAsync().Result;
        }

        /// <summary>
        /// Возвращает существующиq элемент включая дочерние // 
        /// Returns item including subsidiaries
        /// </summary>
        /// <returns>Возвращает существующий элемент включая дочерние / 
        /// Returns item including subsidiaries</returns>
        public override Advert GetWithIncludes(int Id)
        {
            Advert result = _dbContext.Adverts
                .Include(t => t.Type)
                .Include(t => t.Category)
                .Include(t => t.City)
                .FirstOrDefaultAsync(x => x.Id == Id)
                .Result;
            return result;
        }
        /// <summary>
        /// Возвращает существующий элемент не включая дочерние // 
        /// Returns item excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает элемент / 
        /// Getting the adverts list</returns>
        public override Advert GetWithoutIncludes(int Id)
        {
            Advert result = _dbContext
                    .Adverts
                    .FirstOrDefaultAsync(x => x.Id == Id)
                    .Result;
            return result;
        }

        /// <summary>
        /// Функция для получения списка базовой информации об объявлениях
        /// The function to getting a list of a base adverts information 
        /// </summary>
        /// <returns> Общую информацию для заполнения(отображения) объявлений / 
        /// Base infromation to entity filling </returns>
        public override Advert GetInfo()
        {
            throw new NotImplementedException();

        }
    }
}
