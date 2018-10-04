using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RepositoryInterfaces.Base
{
    public interface IRepositoryBase<T, Tid> where  T : Entities.Base.EntityWithTypedIdBase<Tid>
    {
        void Delete(T entity);
        T Get(Tid id);
        IList<T> GetAll();
        T SaveOrUpdate(T entity);
        T New(T entity);
    }
}
