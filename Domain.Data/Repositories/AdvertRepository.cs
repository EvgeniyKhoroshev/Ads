using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Data.Repositories
{
    public class AdvertRepository : Base.BaseRepository<Advert, int>, IAdvertRepository
    {
        /// <summary>
        /// Переменная контекста базы данных // 
        /// Variable of database context
        /// </summary>
        public AdvertRepository(AdsDBContext dbContext) : base(dbContext) { }
        ///// <summary>
        ///// Получение объявления по Id // 
        ///// Getting an advert by Id
        ///// </summary>
        ///// <param name="id">Идентификатор объявления / Id of advert</param>
        ///// <returns>Возвращает объявление / Returns advert</returns>
        //public override async Task<Advert> Get(int id)
        //{
        //    return await _dbContext
        //                        .Adverts
        //                        .FirstOrDefaultAsync(x => x.Id == id);
        //}
        ///// <summary>
        ///// Сохраняет изменения или создает новый элемент, если такого не существует // 
        ///// Save item or create if not exists
        ///// </summary>
        ///// <returns>Возвращает сохраненный или созданый элемент / 
        ///// Returns the created or saved item</returns>
        //public override async Task<int> SaveOrUpdate(Advert entity)
        //{
        //    if (! await _dbContext.Adverts.ContainsAsync(entity))
        //    {
        //        _dbContext.Adverts.Add(entity);
        //        await _dbContext.SaveChangesAsync();
        //        return entity.Id;
        //    }
        //    _dbContext.Adverts.Update(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity.Id;
        //}

        ///// <summary>
        ///// Удаление объявления по Id // 
        ///// Deleting an entity by Id
        ///// </summary>
        ///// <param name="id">Идентификатор объявления / Id of entity</param>
        //public override void Delete(int Id)
        //{
        //    Advert adv = _dbContext.Adverts.FindAsync(Id).Result;
        //    _dbContext.Adverts.Remove(adv);
        //    _dbContext.SaveChangesAsync();
        //}

        //public override IQueryable<Advert> GetAll()
        //{
        //    IQueryable<Advert> some = _dbContext.Adverts;
        //    return some;
        //}
    }

}