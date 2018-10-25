﻿using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces;
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
        public APIRequests(IAdvertRequest advertRequest,
            ICommentRequest commentRequest)
        {
            _advertRequest = advertRequest;
            _commentRequest = commentRequest;
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
            return await _advertRequest.Get(id);
        }
        //public static async Task<List<AdvertDto>> GetAdverts()
        //{

        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/adverts");
        //            if (response.IsSuccessStatusCode)
        //            {
        //                return await response.Content.ReadAsAsync<List<AdvertDto>>();
        //            }
        //        }
        //    }
        //    catch (Exception) { }
        //    return null;
        //}
        public static async Task<JwtSecurityToken> SignIn(UserLoginDto user)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync($"http://localhost:56663/api/authorization/signin", user);
                    if (response.IsSuccessStatusCode)
                    {
                        var jwtToken = await response.Content.ReadAsStringAsync();
                        var h = new JwtSecurityTokenHandler();
                        var s = h.ReadJwtToken(jwtToken) as JwtSecurityToken;
                        return s;
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
