using Ads.Contracts.Dto;
using AutoMapper;
using Domain.Entities;

namespace AppServices
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {

            Mapper.Initialize(cfg => cfg.CreateMap<Advert, AdvertDto>());

        }
    }
}
