using System;
using System.Collections.Generic;

namespace Domain.Data.Repositories.Base
{
    public abstract class BaseRepository<T, Tid> : RepositoryInterfaces.Base.IRepositoryBase<T, int> 
        where T: Entities.Base.BaseEntity
    {
        public BaseRepository() { }
        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }
        public virtual IList<T> GetAllWithIncluding()
        {
            throw new NotImplementedException();
        }
        public virtual IList<T> GetAllWithoutIncluding()
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

        public virtual T GetInfo()
        {
            throw new NotImplementedException();
        }

        public virtual T GetWithIncludes(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual T GetWithoutIncludes(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetAllWithIncludes()
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetWithoutIncludes()
        {
            throw new NotImplementedException();
        }
    }
}
