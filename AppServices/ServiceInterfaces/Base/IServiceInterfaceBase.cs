using System.Collections.Generic;

namespace AppServices.ServiceInterfaces.Base
{
    public interface IServiceInterfaceBase<T, Tid>
    {
        IList<T> GetAllWithIncludes(Tid id);
        IList<T> GetAllWithoutIncludes(Tid id);
        int Create();
        T SaveOrUpdate(T Entity);
        T Get(Tid id);

    }
}
