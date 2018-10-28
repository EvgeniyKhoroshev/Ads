using Ads.Contracts.Dto.Filters;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers.Components.ApiRequests.BaseRequest
{
    public abstract class BaseRequest<T, Tid> : IBaseRequest<T, Tid>, IDisposable
    {
        private HttpClient httpClient;
        private string entityName;
        public BaseRequest(string Name)
        {
            entityName = Name;
            httpClient = new HttpClient();
        }
        private readonly string _apiUrl = "http://localhost:56663/api/";
        /// <summary>
        /// Http запрос к API для удаления <paramref name="entityName"/> по Id
        /// / HTTP request to deleting a <paramref name="entityName"/> by Id
        /// </summary>
        /// <param name="entityName">Подстрока запроса к Api / 
        /// URL substring to request api</param>
        /// <param name="Id"> Идентификатор <paramref name="entityName"/> / 
        /// Id of a <paramref name="entityName"/></param>
        public virtual async Task Delete(Tid id)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync(_apiUrl + entityName + "/"+id);
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос Delete(" + entityName + ", id = " + id + " произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }

        }
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
        public virtual async Task<T> Get(Tid Id)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.GetAsync(_apiUrl + entityName + "/"+Id);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<T>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить Get(" + entityName + ", id = "+Id+") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
            return default(T);
        }
        /// <summary>
        /// Http запрос к API для получения всех <paramref name="entity"/>
        /// / HTTP request to getting all of <paramref name="entity"/>
        /// </summary>
        /// <param name="entityName">Подстрока запроса к Api / 
        /// URL substring to request api</param>
        /// <returns> Сохраненная сущность /
        /// List of <paramref name="entity"/></returns>
        public virtual async Task<IList<T>> GetAll()
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.GetAsync(_apiUrl + entityName);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<IList<T>>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос GetAll(" + entityName + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
            return default(IList<T>);
        }
        /// <summary>
        /// Http запрос к API для получения всех <paramref name="entity"/> с фильтром
        /// / HTTP request to getting all of <paramref name="entity"/> with filter
        /// </summary>
        /// <param name="entityName">Подстрока запроса к Api / 
        /// URL substring to request api</param>
        /// <returns> Сохраненная сущность /
        /// List of <paramref name="entity"/></returns>
        public virtual async Task<IList<T>> GetFiltred(FilterDto filter)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(_apiUrl + entityName+"/filter", filter);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<IList<T>>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос GetFiltred(" + entityName + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
            return default(IList<T>);
        }
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
        public virtual async Task<T> SaveOrUpdate(T entity)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(_apiUrl + entityName+"/saveorupdate", entity);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<T>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить SaveOrUpdate(" + entityName + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
            return default(T);
        }

        public void Dispose()
        {
            ((IDisposable)httpClient).Dispose();
        }
    }
}
