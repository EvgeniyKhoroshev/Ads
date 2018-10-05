using System.Collections.Generic;

namespace AppServices.ServiceInterfaces.Base
{
    public interface IServiceInterfaceBase<T, Tid>
    {
        IList<T> GetAllWithIncludes();
        IList<T> GetAllWithoutIncludes();
        int Create();
        T SaveOrUpdate(T Entity);
        T GetWithoutIncludes(Tid id);
        T GetWithIncludes(Tid id);

    }
}
