using Ads.CoreService.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.BaseClients;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces;
using Ads.MVCClientApplication.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Ads.Shared.Contracts.Areas;

namespace Ads.MVCClientApplication.Controllers.Components.ApiClients.AdvertRequests
{
    public class ApiAdvertClient : ApiBaseClient<AdvertDto, int>,  IApiAdvertClient
    {
        public ApiAdvertClient(IHttpContextAccessor context,
            IOptions<ApiBaseOption> opt,
            IOptions<ApiAdvertsArea> adv) : base(context, opt, adv) { }
        public async Task<PagedCollection<AdvertDto>> GetFiltredAsync(AdvertFilterDto filter)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(_options.ApiEndpoint + _area.Get + "/filter", filter);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<PagedCollection<AdvertDto>>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос GetFiltred(" + _area.Get + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
            return default(PagedCollection<AdvertDto>);
        }
        // <inheritdoc>
        public async Task<IList<CommentDto>> GetAdvertCommentsAsync(int advertId)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_options.ApiEndpoint}{_area.Get}/{advertId}/advertcomments/");
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<IList<CommentDto>>();
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
    }
}
