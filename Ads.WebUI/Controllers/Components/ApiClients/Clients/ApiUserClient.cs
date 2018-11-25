using Ads.CoreService.Contracts.Dto;
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
                        string err = "При попытке получить объявления пользователя(id = " + userId + ") произошла ошибка. " + response.StatusCode;
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
        public async Task ChangeAvatarAsync(UserAvatarDto avatar)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient
                        .PostAsJsonAsync($"{ _options.ApiEndpoint }/Authorization/ChangeAvatar", avatar);
                    if (!response.IsSuccessStatusCode)
                    {
                        string err = "При попытке сменить аватар пользователя(id = " + avatar.UserId + ") произошла ошибка. " + response.StatusCode;
                        throw new HttpRequestException(string.Join(Environment.NewLine, err));
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос" + "(UserId = " + avatar.UserId + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
        }
        public async Task<ManageVM> GetUserInfoAsync(int userId)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{ _options.ApiEndpoint }/Authorization/GetUserInfo/{userId}");

                    if (response.IsSuccessStatusCode)
                    {
                        var dto = await response.Content.ReadAsAsync<UserInfoDto>();
                        return Mapper.Map<ManageVM>(dto);
                    }
                    else
                    {
                        string err = "При попытке получить объявления пользователя(id = " + userId + ") произошла ошибка. " + response.StatusCode;
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

        public async Task ChangeUserInfoAsync(UserInfoDto userInfo)
        {
            try
            {
                using (httpClient)
                {
                    HttpResponseMessage response = 
                        await httpClient.PostAsJsonAsync($"{_options.ApiEndpoint}/Authorization/ChangeUserInfo", userInfo);
                    if (!response.IsSuccessStatusCode)
                    {
                        string err = "При попытке изменить данные пользователя(id = " + userInfo.Id + ") произошла ошибка." + response.StatusCode;
                        throw new HttpRequestException(string.Join(Environment.NewLine, err));
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string err = "При попытке выполнить запрос" + "(UserId = " + userInfo.Id + ") произошла ошибка. " + ex.Message;
                throw new HttpRequestException(string.Join(Environment.NewLine, err));
            }
        }
    }
}