using AppServices.ServiceInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.Services.Base
{
    public abstract class BaseService<T, Tid> : IServiceInterfaceBase<T, Tid>
    {

        public virtual void Delete(Tid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> SaveOrUpdate(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> Get(Tid id)
        {
            throw new NotImplementedException();
        }
        public virtual IList<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
