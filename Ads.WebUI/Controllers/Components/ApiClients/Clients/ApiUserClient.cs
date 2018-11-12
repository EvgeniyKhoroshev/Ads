using Ads.Contracts.Dto;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.BaseClients;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Ads.Shared.Contracts;
using Ads.Shared.Contracts.Areas;
using Ads.MVCClientApplication.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System;
using AutoMapper;

namespace Ads.MVCClientApplication.Controllers.Components.ApiClients.Clients
{
    public class ApiUserClient : ApiBaseClient<UserLoginDto, int>, IApiUserClient
    {
        public ApiUserClient(IHttpContextAccessor context,
            IOptions<ApiBaseOption> opt,
            IOptions<ApiUsersArea> users) : base(context, opt, users) { }

        public async Task<AdsVMIndex[]> GetUserAdvertsAsync(int userId)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{ _options.ApiEndpoint }{_area.Get}/{userId}");

                    if (response.IsSuccessStatusCode)
                    {
                        var dto = await response.Content.ReadAsAsync<List<AdvertDto>>();
                        return Mapper.Map<AdsVMIndex[]>(dto);
                    }
                    else
                    {
                        string err = "При попытке получить объявления пользователя(id = " + userId + ") произошла ошибка. " +response.StatusCode;
                        throw new HttpRequestException(string.Join(Environment.NewLine, err));
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить Get(" + _area.Get + ", id = " + userId + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
        }
    }
}
