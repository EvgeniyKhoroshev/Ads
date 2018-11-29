using Ads.CoreService.Contracts.Dto;
using Ads.MVCClientApplication.Components.ApiClients.Interfaces.Base;
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
        Task<bool> SetRatingAsync(RatingDto ratingDto);
        /// <summary>
        /// Получение списка оцененных постов текущего пользователя которые находятся в объявлении <paramref name="advertId"/>
        /// </summary>
        /// <param name="advertId">Id объявления</param>
        /// <returns>Список оценок постов.</returns>
        Task<RatingDto[]> GetCurrentUserRatesAsync(int advertId);
    }
}
