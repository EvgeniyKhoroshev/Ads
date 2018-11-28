using Ads.CoreService.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.MVCClientApplication.Components.ApiClients.Interfaces;
using Ads.Shared.Contracts;
using Ads.MVCClientApplication.Models;
using Authentication.Contracts.Basic;
using Authentication.Contracts.JwtAuthentication;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Класс для работы с HTTP запросами к API/ 
/// The class for a connection with API by a HTTP query
/// </summary>
namespace Ads.MVCClientApplication.Components.ApiRequests
{
    public class ApiClient
    {
        readonly IApiUserClient _apiUserClient;
        readonly IApiAdvertClient _advertClient;
        readonly IApiCommentsClient _commentClient;
        readonly IHttpContextAccessor _context;
        public ApiClient(IApiAdvertClient advertRequest,
            IApiCommentsClient commentRequest,
            IHttpContextAccessor context,
            IApiUserClient apiUserClient)
        {
            _apiUserClient = apiUserClient;
            _advertClient = advertRequest;
            _commentClient = commentRequest;
            _context = context;
        }

        /// <summary>
        /// Инициализатор обьекта, в котором хранится дополнительная информация об объявлениях/ 
        /// The class for a connection with API by a HTTP query
        /// </summary>
        public static async Task<AdvertsInfoDto> AdvInfoInit()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/info");
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<AdvertsInfoDto>();
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
        public async Task<IList<CommentDto>> GetAdvertComments(int id)
        {
            return await _advertClient.GetAdvertCommentsAsync(id);
        }
        public static async Task SignOut()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/authorization/signout");
                }
            }
            catch (Exception ex) { throw new ArithmeticException("Something went wrong. " + ex.Message); }
        }
        public async Task<AdvertDto> GetAdvert(int id)
        {
            return await _advertClient.Get(id);
        }
        public static async Task CreateUser(CreateUserDto user)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync($"http://localhost:56663/api/authorization/create", user);
                    if (response.IsSuccessStatusCode)
                    {
                        await response.Content.ReadAsAsync<CreateUserDto>();
                    }
                }
            }
            catch (Exception) { }
        }
        public async Task<AdvertDto> SaveOrUpdate(AdvertDto advert)
        {
            return await _advertClient.SaveOrUpdate(advert);
        }

        public async Task<CommentDto> SaveOrUpdate(CommentDto comment)
        {
            return await _commentClient.SaveOrUpdate(comment);
        }

        public async Task<PagedCollection<AdsVMIndex>> FiltredAsync(AdvertFilterDto filter)
        {
            var buf = await _advertClient.GetFiltredAsync(filter);
            var result = new PagedCollection<AdsVMIndex>(
                Mapper.Map<AdsVMIndex[]>(buf.Items),
                pageNumber: buf.PageNumber,
                pageSize: buf.PageSize,
                totalPages : buf.TotalPages
                );
            return result;
        }
        public async Task<IList<AdvertDto>> Filter(FilterDto filter)
        {
            return await _advertClient.GetFiltred(filter);
        }
        public async Task DeleteAdvert(int id)
        {
            await _advertClient.Delete(id);
        }
        public async Task DeleteComment(int id)
        {
            await _commentClient.Delete(id);
        }
        public async Task<IList<CommentDto>> GetComments()
        {
            return await _commentClient.GetAll();
        }
    }

}
