using Ads.CoreService.Contracts.Dto;
using Ads.MVCClientApplication.Components.ApiClients.BaseClients;
using Ads.MVCClientApplication.Components.ApiClients.Interfaces;
using Ads.Shared.Contracts;
using Ads.Shared.Contracts.Areas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Components.ApiClients.AdvertRequests
{
    public class ApiCommentsClient : ApiBaseClient<CommentDto, int>, IApiCommentsClient
    {
        public ApiCommentsClient(IHttpContextAccessor context,
            IOptions<ApiBaseOption> opt,
            IOptions<ApiCommentsArea> comm) : base(context, opt, comm) { }

        /// <inheritdoc>
        public async Task<IList<CommentDto>> GetAdvertCommentsAsync(int advertId)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_options.ApiEndpoint}{_area.Get}/advertcomments/{advertId}");
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<IList<CommentDto>>();
                    }
                }
            }
            catch (Exception ex)
            {
                string err = "При попытке выполнить получить комментарии объявления № " + advertId + " произошла ошибка. " + ex.Message;
                throw new Exception(string.Join(Environment.NewLine, err));
            }
            return null;
        }
    }
}
