using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces.Base
{
    public interface IApiBaseClient<T, Tid>
    {
        /// <summary>
        /// Http запрос к API для получения <paramref name="entityName"/> по Id
        /// / HTTP request to getting a <paramref name="entityName"/> by Id
        /// </summary>
        /// <param name="entityName">Подстрока запроса к Api / 
        /// URL substring to request api</param>
        /// <param name="Id"> Идентификатор <paramref name="entityName"/> / 
        /// Id of a <paramref name="entityName"/></param>
        /// <returns> Найденная сущность /
        /// The founded entity </returns>
        Task<T> Get(Tid Id);
        /// <summary>
        /// Http запрос к API для получения всех <paramref name="entity"/>
        /// / HTTP request to getting all of <paramref name="entity"/>
        /// </summary>
        /// <param name="entityName">Подстрока запроса к Api / 
        /// URL substring to request api</param>
        /// <returns> Сохраненная сущность /
        /// List of <paramref name="entity"/></returns>
        Task<IList<T>> GetAll();
        /// <summary>
        /// Http запрос к API для сохранения/создания сущности <paramref name="entity"/> /
        /// HTTP request to api for SaveOrUpdate <paramref name="entity"/>
        /// </summary>
        /// <param name="entityName">Подстрока запроса к Api / 
        /// URL substring to request api</param>
        /// <param name="entity">Параметр для запроса создания или сохранения сущности /
        ///  The parameter to SaveOrUpdate request</param>
        /// <returns>Сохраненная сущность /
        /// Saved entity</returns>
        Task<T> SaveOrUpdate(T entity);
        /// <summary>
        /// Http запрос к API для удаления <paramref name="entityName"/> по Id
        /// / HTTP request to deleting a <paramref name="entityName"/> by Id
        /// </summary>
        /// <param name="entityName">Подстрока запроса к Api / 
        /// URL substring to request api</param>
        /// <param name="Id"> Идентификатор <paramref name="entityName"/> / 
        /// Id of a <paramref name="entityName"/></param>
        Task Delete(Tid id);
        /// <summary>
        /// Http запрос к API для получения всех <paramref name="entity"/> с фильтром
        /// / HTTP request to getting all of <paramref name="entity"/> with filter
        /// </summary>
        /// <param name="entityName">Подстрока запроса к Api / 
        /// URL substring to request api</param>
        /// <returns> Сохраненная сущность /
        /// List of <paramref name="entity"/></returns>
        Task<IList<T>> GetFiltred(FilterDto filter);
        Task<PagedCollection<T>> GetAllPaginatedAsync(PaginationFilterDto filter);
    }
}
