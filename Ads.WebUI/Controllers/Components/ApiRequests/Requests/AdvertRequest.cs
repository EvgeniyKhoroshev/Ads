using Ads.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using Ads.WebUI.Controllers.Components.ApiRequests.BaseRequest;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces;
using Ads.WebUI.Models;
using AutoMapper;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers.Components.ApiRequests.AdvertRequests
{
    public class AdvertRequest : BaseRequest<AdvertDto, int>,  IAdvertRequest
    {
        public AdvertRequest() : base("adverts") { }
        public async Task<PagedCollection<AdvertDto>> GetFiltredAsync(AdvertFilterDto filter)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(_apiUrl + entityName + "/filter", filter);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<PagedCollection<AdvertDto>>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос GetFiltred(" + entityName + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
            return default(PagedCollection<AdvertDto>);
        }
    }
}
