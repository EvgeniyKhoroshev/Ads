using Ads.Contracts.Dto.Filters;
using Ads.Contracts.Dto.Internal;
using Ads.Shared.Contracts;
using AppServices.ServiceInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppServices.Services.Base
{
    public abstract class BaseService<T, Tid> : IServiceInterfaceBase<T, Tid>
    {
        public BaseService()
        {

        }
        /// <summary>
        /// Удаляет объект по указанному идентификатору // 
        /// Delete object from database
        /// </summary>
        /// <param name="id"> Идентификатор объекта </param>
        public virtual void Delete(Tid id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Сохраняет изменения в объекте, если такой объект с таким Id существует в БД, иначе создает новый / 
        /// Saving changes if object with given Id exist in another way creating the new one
        /// Returns all adverts excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает сохраненный или созданный объкт / 
        /// Returns saved or created object</returns>
        public virtual Task<T> SaveOrUpdateAsync(T Entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Возвращает объект по Id// 
        /// Returns an object by Id
        /// </summary>
        public virtual Task<T> GetAsync(Tid id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Возвращает список существующих объектов // 
        /// Returns all existing objects
        /// </summary>
        /// <returns>Возвращает список объектов / 
        /// Getting the objects list</returns>
        public virtual IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual PagedCollection<T> PagedGetFiltredAsync(PaginationFilterDto filter)
        {
            throw new NotImplementedException();
        }
    }
}
