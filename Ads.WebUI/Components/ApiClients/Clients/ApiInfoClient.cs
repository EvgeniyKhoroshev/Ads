using Ads.CoreService.Contracts.Dto;
using Ads.MVCClientApplication.Components.ApiClients.Interfaces;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.BaseClients;
using Ads.Shared.Contracts;
using Ads.Shared.Contracts.Areas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Components.ApiClients.Clients
{
    public class ApiInfoClient : ApiBaseClient<RatingDto, int>, IApiInfoClient
    {
        public ApiInfoClient(IHttpContextAccessor context,
                             IOptions<ApiBaseOption> opt,
                             IOptions<ApiInfoArea> comm)
            : base(context, opt, comm) { }
        public async Task<ActionResult> SetRatingAsync(RatingDto ratingDto)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(_options.ApiEndpoint + _area.Get + "/setrating", ratingDto);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<ActionResult>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос GetFiltred(" + _area.Get + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
            return null;
        }
    }
}
