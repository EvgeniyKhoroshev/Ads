using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using AppServices.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class AdvertService : Base.BaseService<AdvertDto, int>, IAdvertService
    {
        readonly IAdvertRepository _advertRepository;
        public AdvertService(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }
        public override void Delete(int id)
        {
            _advertRepository.Delete(id);
        }
        public override IList<AdvertDto> GetAllWithoutIncludes()
        {
            IQueryable<Advert> adv = _advertRepository.GetAll();
            if (adv == null)
                return null;
            AdvertDto [] result;
            result = Mapper.Map<AdvertDto[]>(adv.ToArray());
            return result;
        }
        public override async Task<AdvertDto> SaveOrUpdate(AdvertDto entity)
        {
            Advert sm = await _advertRepository.SaveOrUpdate(Mapper.Map<Advert>(entity));
            return Mapper.Map<AdvertDto>(sm);
        }
        /// <summary>
        /// Возвращает список существующих объявлений не включая дочерние // 
        /// Returns all adverts excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает список объявлений / 
        /// Getting the adverts list</returns>
        public override async Task<AdvertDto> GetWithoutIncludes(int id)
        {
            Advert adv = await _advertRepository.GetWithoutIncludes(id);
            if (adv == null)
                return null;
            return  Mapper.Map<AdvertDto>(adv) ;
        }
        /// <summary>
        /// Возвращает список существующих объявлений включая дочерние // 
        /// Returns all adverts including subsidiaries
        /// </summary>
        /// <returns>Возвращает список существующих объявлений включая дочерние / 
        /// Returns all adverts including subsidiaries</returns>
        public override async Task<AdvertDto> GetWithIncludes(int id)
        {
            Advert adv = await _advertRepository.GetWithIncludes(id);
            if (adv == null)
                return null;
            return Mapper.Map<AdvertDto>(adv);
        }

        public AdvertDto[] GetFiltred(FilterDto filter)
        {
            var query = _advertRepository.GetAll();

            if (filter.PriceRange != null)
            {
                if (filter.PriceRange.MinValue.HasValue)
                    query = query.Where(x => x.Price >= filter.PriceRange.MinValue);
                if (filter.PriceRange.MaxValue.HasValue)
                    query = query.Where(x => x.Price <= filter.PriceRange.MaxValue);
            }


            var entities = query.ToArray();

            return Mapper.Map<AdvertDto[]>(entities);
        }
    }
}

