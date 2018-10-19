using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces.Base
{
    public interface IServiceInterfaceBase<T, Tid>
    {
        Task<T> SaveOrUpdate(T Entity);
        Task<T> Get(Tid id);
        IList<T> GetAll();
        void Delete(Tid id);

    }
}
