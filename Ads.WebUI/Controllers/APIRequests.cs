using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Класс для работы с HTTP запросами к API/ 
/// The class for a connection with API by a HTTP query
/// </summary>
namespace Ads.WebUI.Controllers
{
    public class APIRequests
    {
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
        public static async Task<AdvertDto> GetAdvert(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/adverts/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<AdvertDto>();
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
        public static async Task<List<AdvertDto>> GetAdverts()
        {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/adverts");
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<List<AdvertDto>>();
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
        public static async Task<AdvertDto> CreateAdvert(AdvertDto advert)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync($"http://localhost:56663/api/adverts/saveorupdate", advert);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<AdvertDto>();
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
        public static async Task<AdvertDto[]> Filter(FilterDto advert)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync($"http://localhost:56663/api/adverts/filter", advert);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<AdvertDto[]>();
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
        public static async Task DeleteAdvert(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:56663/api/adverts/{id}");
                }
            }
            catch(Exception) { }
        }

        public static async Task<CommentDto[]> GetComments_Request()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/comments");
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<CommentDto[]>(); 
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Возникло исключение при попытке получить комментарии. "+
                ex.Message); }
            return null;
        }
    }

}
