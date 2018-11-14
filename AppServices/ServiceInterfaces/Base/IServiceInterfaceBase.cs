using Ads.CoreService.Contracts.Dto.Internal;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces.Base
{
    public interface IServiceInterfaceBase<T, Tid>
    {
        /// <summary>
        /// Сохраняет изменения в объекте, если такой объект с таким Id существует в БД, иначе создает новый / 
        /// Saving changes if object with given Id exist in another way creating the new one
        /// Returns all adverts excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает сохраненный или созданный объкт / 
        /// Returns saved or created object</returns>
        Task<T> SaveOrUpdateAsync(T Entity);
        /// <summary>
        /// Возвращает объект по Id// 
        /// Returns an object by Id
        /// </summary>
        Task<T> GetAsync(Tid id);
        /// <summary>
        /// Возвращает список существующих объектов // 
        /// Returns all existing objects
        /// </summary>
        /// <returns>Возвращает список объектов / 
        /// Getting the objects list</returns>
        IList<T> GetAll();
        /// <summary>
        /// Удаляет объект по указанному идентификатору // 
        /// Delete object from database
        /// </summary>
        /// <param name="id"> Идентификатор объекта </param>
        void Delete(Tid id);
        PagedCollection<T> PagedGetFiltredAsync(PaginationFilterDto filter);
    }
}
