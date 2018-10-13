using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Data.Repositories.Base
{
    public abstract class BaseRepository<T, Tid> : RepositoryInterfaces.Base.IRepositoryBase<T, int> 
        where T: Entities.Base.BaseEntity
    {
        public BaseRepository() { }
        public virtual Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }
        public virtual Task<IList<T>> GetAllWithIncludes()
        {
            throw new NotImplementedException();
        }
        public virtual Task<IList<T>> GetAllWithoutIncludes()
        {
            throw new NotImplementedException();
        }
        public virtual Task<T> New(T entity)
        {
            throw new NotImplementedException();
        }
        public virtual Task<T> SaveOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetInfo()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetWithIncludes(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetWithoutIncludes(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
