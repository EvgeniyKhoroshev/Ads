using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
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

        IList<CommentDto> GetAdvertComments(int advertId);
    }
}
