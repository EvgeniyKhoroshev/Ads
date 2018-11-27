using Ads.CoreService.Contracts.Dto;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Components.ApiClients.Interfaces
{
    public interface IApiInfoClient : IApiBaseClient<RatingDto, int>
    {
        /// <summary>
        /// Выполняет запрос к API для установки рейтинга к посту.
        /// </summary>
        /// <param name="ratingDto"></param>
        /// <returns>Возвращает true, если операция прошла успешно.</returns>
        Task<ActionResult> SetRatingAsync(RatingDto ratingDto);
    }
}
