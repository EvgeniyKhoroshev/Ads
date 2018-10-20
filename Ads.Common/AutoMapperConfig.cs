using Ads.Contracts.Dto;
using Ads.WebUI.Models;
using AutoMapper;
using Domain.Entities;

namespace Ads.Common
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Advert, AdvertDto>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<AdvertDto, Advert>();
                cfg.CreateMap<AdvertsInfo, AdvertsInfoDto>();
                cfg.CreateMap<AdvertsInfoDto, AdvertsInfo>();
                cfg.CreateMap<AdvertDto, AdsVMIndex>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<AdsVMIndex, AdvertDto>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<CommentDto, Comment>();
                cfg.CreateMap<Comment, CommentDto>();
            });
        }
    }
}
