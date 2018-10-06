using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System.Collections.Generic;
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
        public override async Task<IList<AdvertDto>> GetAllWithoutIncludes()
        {
            IList<Advert> adv = await _advertRepository.GetAllWithoutIncludes();
            if (adv == null)
                return null;
            IList<AdvertDto> result = new List<AdvertDto>();
            foreach (var ads in adv)
                result.Add(Mapper.Map<AdvertDto>(ads));
            return result;
        }
        public override AdvertDto SaveOrUpdate(AdvertDto entity)
        {
            Advert sm = _advertRepository.SaveOrUpdate(Mapper.Map<Advert>(entity)).Result;
            return Mapper.Map<AdvertDto>(sm);
        }
        public override async Task<AdvertDto> GetWithoutIncludes(int id)
        {
            Advert adv = await _advertRepository.GetWithoutIncludes(id);
            if (adv == null)
                return null;
            return  Mapper.Map<AdvertDto>(adv) ;
        }
        public override async Task<AdvertDto> GetWithIncludes(int id)
        {
            Advert adv = await _advertRepository.GetWithIncludes(id);
            if (adv == null)
                return null;
            return Mapper.Map<AdvertDto>(adv);
        }
    }
}
