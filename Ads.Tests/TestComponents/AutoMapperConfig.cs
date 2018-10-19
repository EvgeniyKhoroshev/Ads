using Ads.Contracts.Dto;
using AutoMapper;
using Domain.Entities;

namespace Ads.Tests
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Domain.Entities.Advert, AdvertDto>();
                cfg.CreateMap<AdvertDto, Domain.Entities.Advert>();
                cfg.CreateMap<AdvertsInfo, AdvertsInfoDto>();
                cfg.CreateMap<AdvertsInfoDto, AdvertsInfo>();
                cfg.CreateMap<CommentDto, Comment>();
                cfg.CreateMap<Comment, CommentDto>();
            });
        }
    }
}
