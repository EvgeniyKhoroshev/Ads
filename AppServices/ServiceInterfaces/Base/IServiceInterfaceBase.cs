using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces.Base
{
    public interface IServiceInterfaceBase<T, Tid>
    {
        IList<T> GetAllWithIncludes();
        IList<T> GetAllWithoutIncludes();
        Task<int> Create();
        Task<T> SaveOrUpdate(T Entity);
        Task<T> GetWithoutIncludes(Tid id);
        Task<T> GetWithIncludes(Tid id);
        Task<T> GetInfo();
        void Delete(Tid id);

    }
}
