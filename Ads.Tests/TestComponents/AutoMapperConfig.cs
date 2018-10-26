using Ads.Contracts.Dto;
using AutoMapper;
using Domain.Entities;

namespace Ads.Tests
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Advert, AdvertDto>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<AdvertDto, Advert>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<Ads.Contracts.Dto.City, Domain.Entities.City>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<AdvertsInfo, AdvertsInfoDto>();
                cfg.CreateMap<AdvertsInfoDto, AdvertsInfo>();
                cfg.CreateMap<CommentDto, Comment>();
                cfg.CreateMap<Comment, CommentDto>();
            });
        }
    }
}
