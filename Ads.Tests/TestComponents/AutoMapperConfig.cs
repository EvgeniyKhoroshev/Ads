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
                .ForMember(dest => dest.CategoryId,
                opt => opt.MapFrom(x => x.Category.Id))
                .ForMember(dest => dest.TypeId,
                opt => opt.MapFrom(x => x.Type.Id))
                .ForMember(dest => dest.StatusId,
                opt => opt.MapFrom(x => x.Status.Id))
                .ForMember(dest => dest.CityId,
                opt => opt.MapFrom(x => x.City.Id));
                cfg.CreateMap<AdvertsInfo, AdvertsInfoDto>();
                cfg.CreateMap<AdvertsInfoDto, AdvertsInfo>();
                cfg.CreateMap<CommentDto, Comment>();
                cfg.CreateMap<Comment, CommentDto>();
            });
        }
    }
}
