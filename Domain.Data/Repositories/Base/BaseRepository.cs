using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Data.Repositories.Base
{
    public abstract class BaseRepository<T, Tid> : RepositoryInterfaces.Base.IRepositoryBase<T, int>
        where T : Entities.Base.BaseEntity
    {
        protected readonly AdsDBContext _dbContext;

        public BaseRepository(AdsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> Get(int id)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            return result;
        }
        public virtual async Task<int> SaveOrUpdate(T entity)
        {
            if ((await _dbContext.Set<T>().FirstOrDefaultAsync(t => t.Id == entity.Id)) != null)
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity.Id;
            }
            else
            {
                _dbContext.Set<T>().Add(entity);
                _dbContext.SaveChanges();
            }
            return 0;
        }


        public virtual void Delete(int Id)
        {
            try
            {
                _dbContext.Set<T>().Remove(Get(Id).Result);
                _dbContext.SaveChanges();
            }
            catch (Exception) { }
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
    }
}
