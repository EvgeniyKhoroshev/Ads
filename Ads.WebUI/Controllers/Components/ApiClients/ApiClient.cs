using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using Ads.WebUI.Controllers.Components.ApiClients.Interfaces;
using Ads.WebUI.Models;
using Authentication.AppServices.Extensions;
using Authentication.Contracts.Basic;
using Authentication.Contracts.JwtAuthentication;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

/// <summary>
/// Класс для работы с HTTP запросами к API/ 
/// The class for a connection with API by a HTTP query
/// </summary>
namespace Ads.WebUI.Components.ApiRequests
{
    public class ApiClient
    {
        readonly IApiAdvertClient _advertRequest;
        readonly IApiCommentsClient _commentRequest;
        readonly IHttpContextAccessor _context;
        readonly string _authToken;
        public ApiClient(IApiAdvertClient advertRequest,
            IApiCommentsClient commentRequest,
            IHttpContextAccessor context)
        {
            _advertRequest = advertRequest;
            _commentRequest = commentRequest;
            _context = context;
            _authToken = _context.HttpContext.User.GetAuthToken();
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
            return await _advertRequest.GetAdvertCommentsAsync(id);
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
            return await _advertRequest.Get(id);
        }
        public static async Task<ActionResult<JwtAuthenticationToken>> SignIn(BasicAuthenticationRequest user)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync($"http://localhost:56663/JwtAuthentication", user);
                    if (response.IsSuccessStatusCode)
                    {
                        var jwtToken = await response.Content.ReadAsAsync<JwtAuthenticationToken>();
                        return jwtToken;
                    }
                }
            }
            catch (Exception ex) { throw new ArithmeticException("Something went wrong. " + ex.Message); }
            return null;
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
            return await _advertRequest.SaveOrUpdate(advert);
        }

        public async Task<CommentDto> SaveOrUpdate(CommentDto comment)
        {
            return await _commentRequest.SaveOrUpdate(comment);
        }

        public async Task<PagedCollection<AdsVMIndex>> FiltredAsync(AdvertFilterDto filter)
        {
            var buf = await _advertRequest.GetFiltredAsync(filter);
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
            return await _advertRequest.GetFiltred(filter);
        }
        public async Task DeleteAdvert(int id)
        {
            await _advertRequest.Delete(id);
        }
        public async Task DeleteComment(int id)
        {
            await _commentRequest.Delete(id);
        }
        public async Task<IList<CommentDto>> GetComments()
        {
            return await _commentRequest.GetAll();
        }
    }

}
