using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace AppServices.Services
{
    public class AdvertService : Base.BaseService<AdvertDto, int>, IAdvertService
    {
        readonly IAdvertRepository _advertRepository;
        public AdvertService(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }
        public override AdvertDto Get(int id)
        {
            Advert adv = _advertRepository.Get(id);
            if (adv == null)
                return null;
            Mapper.Initialize(cfg => cfg.CreateMap<Advert, AdvertDto>());
            return  Mapper.Map<AdvertDto>(adv) ;
        }
    }
}
