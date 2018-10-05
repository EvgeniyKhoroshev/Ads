﻿using AppServices.ServiceInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.Services.Base
{
    public abstract class BaseService<T, Tid> : IServiceInterfaceBase<T, Tid>
    {
        public virtual IList<T> GetAllWithIncludes()
        {
            throw new NotImplementedException();
        }
        public virtual IList<T> GetAllWithoutIncludes()
        {
            throw new NotImplementedException();
        }
        public virtual int Create()
        {
            throw new NotImplementedException();
        }

        public virtual T SaveOrUpdate(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual T GetWithoutIncluding(Tid id)
        {
            throw new NotImplementedException();
        }
        public virtual T GetWithoutIncludes(Tid id)
        {
            throw new NotImplementedException();
        }

        public virtual T GetWithIncludes(Tid id)
        {
            throw new NotImplementedException();
        }
    }
}
