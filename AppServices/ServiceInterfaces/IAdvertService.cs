using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.ServiceInterfaces
{
    public interface IAdvertService : Base.IServiceInterfaceBase<AdvertDto, int>
    {
        /// <summary>
        /// Возвращает массив объявлений, отфильтрованных по условиям, указанным в <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">Фильтр объявлений.</param>
        AdvertDto[] GetFiltred(FilterDto filter);
        /// <summary>
        /// Функция для получения списка комментариев объявления с заданным Id //
        /// The function to get a comments from advert by the given advert Id
        /// </summary>
        /// <param name="advertId">Идентификатор объявления //
        /// Advert Id</param>
        /// <returns>Список комментариев, принадлежащих объявлению с заданным Id//
        /// List of a comments from advert with a given Id</returns>
        IList<CommentDto> GetAdvertComments(int advertId);
        /// <summary>
        /// Возвращает список существующих объявлений с данными для вывода на главную страницу // 
        /// Returns all existing adverts with a data for index page output
        /// </summary>
        /// <returns>Возвращает список объявлений с данными для вывода на главную страницу / 
        /// Getting the adverts list with a data for index page output</returns>
        IList<AdvertDto> GetAll_ToIndex();
        /// <summary>
        /// Возвращает постраничную коллекцию объявлений, отфильтрованных по условиям, указанным в <paramref name="filter"/> / 
        /// Getting the paged adverts filtred by the 
        /// </summary>
        /// <param name="filter">Фильтр объявлений / 
        /// Adverts filter</param>
        PagedCollection<AdvertDto> GetFilteredAsync(AdvertFilterDto filter);

    }
}
