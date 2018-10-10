using Ads.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers
{
    public class APIRequests
    {
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

        public static async Task<List<AdvertDto>> GetAdverts()
        {
            List<AdvertDto> result = null;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/adverts");
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<List<AdvertDto>>();
                        return result;
                    }
                }
            }
            catch (Exception) { }
            return result;
        }
        public static async Task<AdvertDto> CreateAdvert(AdvertDto advert)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync($"http://localhost:56663/api/adverts/create", advert);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<AdvertDto>();
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
    }
}
