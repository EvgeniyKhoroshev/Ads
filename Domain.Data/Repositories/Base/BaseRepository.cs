using System;
using System.Collections.Generic;

namespace Domain.Data.Repositories.Base
{
    public abstract class BaseRepository<T, Tid> : RepositoryInterfaces.Base.IRepositoryBase<T, int> 
        where T: Entities.Base.BaseEntity
    {
        public BaseRepository() { }
        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetAll()
        {
            throw new NotImplementedException();
        }
        public virtual T New(T entity)
        {
            throw new NotImplementedException();
        }
        public virtual T SaveOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
