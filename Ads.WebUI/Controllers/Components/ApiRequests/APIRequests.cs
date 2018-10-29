using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces;
using Authentication.AppServices.Extensions;
using Authentication.Contracts.Basic;
using Authentication.Contracts.JwtAuthentication;
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
    public class APIRequests
    {
        readonly IAdvertRequest _advertRequest;
        readonly ICommentRequest _commentRequest;
        readonly IHttpContextAccessor _context;
        readonly string _authToken;
        public APIRequests(IAdvertRequest advertRequest,
            ICommentRequest commentRequest,
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
        public static async Task<IList<CommentDto>> GetAdvertComments(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/adverts/{id}/advertcomments");
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<IList<CommentDto>>();
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
        public async Task<AdvertDto> GetAdvert(int id)
        {
            return await _advertRequest.Get(id, _authToken);
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
            return await _advertRequest.SaveOrUpdate(advert, _authToken);
        }

        public async Task<CommentDto> SaveOrUpdate(CommentDto comment)
        {
            return await _commentRequest.SaveOrUpdate(comment, _authToken);
        }

        public async Task<IList<AdvertDto>> Filter(FilterDto filter)
        {
            return await _advertRequest.GetFiltred(filter);
            //try
            //{
            //    using (var httpClient = new HttpClient())
            //    {
            //        HttpResponseMessage response = await httpClient.PostAsJsonAsync($"http://localhost:56663/api/adverts/filter", advert);
            //        if (response.IsSuccessStatusCode)
            //        {
            //            return await response.Content.ReadAsAsync<AdvertDto[]>();
            //        }
            //    }
            //}
            //catch (Exception) { }
            //return null;
        }
        public async Task DeleteAdvert(int id)
        {
            await _advertRequest.Delete(id, _authToken);
        }
        public async Task DeleteComment(int id)
        {
            await _commentRequest.Delete(id, _authToken);
        }
        public async Task<IList<CommentDto>> GetComments()
        {
            return await _commentRequest.GetAll();
        }
    }

}
