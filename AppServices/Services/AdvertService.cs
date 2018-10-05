using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class AdvertService : Base.BaseService<AdvertDto, int>, IAdvertService
    {
        readonly IAdvertRepository _advertRepository;
        public AdvertService(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }
        public override IList<AdvertDto> GetAllWithoutIncludes()
        {
            IList<Advert> adv = _advertRepository.GetWithoutIncludes();
            if (adv == null)
                return null;
            IList<AdvertDto> result = new List<AdvertDto>();
            foreach (var ads in adv)
                result.Add(Mapper.Map<AdvertDto>(ads));
            return result;
        }
        public override AdvertDto GetWithoutIncludes(int id)
        {
            Advert adv = _advertRepository.GetWithoutIncludes(id);
            if (adv == null)
                return null;
            return  Mapper.Map<AdvertDto>(adv) ;
        }
    }
}
