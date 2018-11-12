using Ads.MVCClientApplication.Models;
using Authentication.Contracts.Basic;
using Authentication.Contracts.JwtAuthentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces
{
    public interface IApiUserClient
    {
        /// <summary>
        /// Получение всех объявлений текущего пользователя.
        /// </summary>
        /// <returns>Список VM объявлений. </returns>
        Task<AdsVMIndex[]> GetUserAdvertsAsync(int userId);
    }
}
