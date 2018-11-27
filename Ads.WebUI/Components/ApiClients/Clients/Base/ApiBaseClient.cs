using Ads.CoreService.Contracts.Dto.Filters;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces.Base;
using Authentication.AppServices.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Ads.Shared.Contracts;
using Microsoft.Extensions.Options;
using Ads.Shared.Contracts.Areas;
using Microsoft.AspNetCore.Mvc;

namespace Ads.MVCClientApplication.Controllers.Components.ApiClients.BaseClients
{
    public abstract class ApiBaseClient<T, Tid> : IApiBaseClient<T, Tid>, IDisposable
    {
        public HttpClient httpClient;
        public readonly IHttpContextAccessor _context;
        public readonly string _authToken;
        public readonly ApiBaseOption _options;
        public readonly ApiBaseArea _area;
        public ApiBaseClient(IHttpContextAccessor context,
            IOptions<ApiBaseOption> options,
            IOptions<ApiBaseArea> area)
        {
            _area = area.Value;
            _options = options.Value;
            _context = context;
            httpClient = new HttpClient();
            _authToken = _context.HttpContext.User.GetAuthToken();
            httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), $"Bearer {_authToken}");
        }
        /// <summary>
        /// Http запрос к API для удаления <paramref name="entityName"/> по Id
        /// / HTTP request to deleting a <paramref name="entityName"/> by Id
        /// </summary>
        /// <param name="entityName">Подстрока запроса к Api / 
        /// URL substring to request api</param>
        /// <param name="Id"> Идентификатор <paramref name="entityName"/> / 
        /// Id of a <paramref name="entityName"/></param>
        public virtual async Task<ActionResult> Delete(Tid id)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{_options.ApiEndpoint}{_area.Get}/{id}");
                    if (response.IsSuccessStatusCode)
                        return new StatusCodeResult(200);
                    else
                        return new StatusCodeResult(400);
                }
                //}
                //    var request = new HttpRequestMessage(HttpMethod.Delete, $"{ _options.ApiEndpoint }{entityName}/{id}")
                //    {
                //        Headers = {
                //    { HttpRequestHeader.ContentType.ToString(), "application/json"},
                //    { HttpRequestHeader.Authorization.ToString(), $"Bearer {token}"}
                //}
                //    };
                //HttpResponseMessage response = await httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос Delete(" + _area.Get + ", id = " + id + " произошла ошибка. " + ex.Message;
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
                    HttpResponseMessage response = await httpClient.GetAsync($"{ _options.ApiEndpoint }{_area.Get}/{Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<T>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить Get(" + _area.Get + ", id = " + Id + ") произошла ошибка. " + ex.Message;
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
                    HttpResponseMessage response = await httpClient.GetAsync(_options.ApiEndpoint + _area.Get);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<IList<T>>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос GetAll(" + _area.Get + ") произошла ошибка. " + ex.Message;
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
        public virtual async Task<PagedCollection<T>> GetAllPaginatedAsync(PaginationFilterDto filter)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(_options.ApiEndpoint + _area.Get + "/paged", filter);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<PagedCollection<T>>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос GetFiltred(" + _area.Get + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
            return default(PagedCollection<T>);
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
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(_options.ApiEndpoint + _area.Get + "/filter", filter);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<IList<T>>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос GetFiltred(" + _area.Get + ") произошла ошибка. " + ex.Message;
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
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(_options.ApiEndpoint + _area.Get + "/saveorupdate", entity);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                string err = $"При попытке выполнить SaveOrUpdate({_area.Get}) произошла ошибка. {ex.Message}";
                throw new Exception(string.Join(Environment.NewLine, err));
            }
            return default(T);
        }
        public void Dispose()
        {
            ((IDisposable)httpClient).Dispose();
        }
    }
}
