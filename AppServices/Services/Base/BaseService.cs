using AppServices.ServiceInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.Services.Base
{
    public abstract class BaseService<T, Tid> : IServiceInterfaceBase<T, Tid>
    {
        public virtual Task<T> GetInfo()
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
        public virtual Task<int> Create()
        {
            throw new NotImplementedException();
        }
        public virtual void Delete(Tid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> SaveOrUpdate(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetWithoutIncluding(Tid id)
        {
            throw new NotImplementedException();
        }
        public virtual Task<T> GetWithoutIncludes(Tid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetWithIncludes(Tid id)
        {
            throw new NotImplementedException();
        }
    }
}
