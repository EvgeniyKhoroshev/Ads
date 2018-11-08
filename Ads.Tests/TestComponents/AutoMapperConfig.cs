using Ads.Contracts.Dto;
using AutoMapper;
using Domain.Entities;

namespace Ads.Tests
{
    public class AutoMapperConfig
    {

        private static object _thisLock = new object();
        private static bool _initialized = false;

        public static void Initialize()
        {
            //Mapper.Reset();
            lock (_thisLock)
            {
                if (!_initialized)
                {
                    Mapper.Initialize(cfg => {
                        cfg.CreateMap<Advert, AdvertDto>()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter()
                            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                        cfg.CreateMap<AdvertDto, Advert>()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter()
                            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                        cfg.CreateMap<Ads.Contracts.Dto.CityDto, Domain.Entities.City>()
                            .IgnoreAllPropertiesWithAnInaccessibleSetter()
                            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                        cfg.CreateMap<AdvertsInfo, AdvertsInfoDto>();
                        cfg.CreateMap<AdvertsInfoDto, AdvertsInfo>();
                        cfg.CreateMap<CommentDto, Comment>();
                        cfg.CreateMap<Comment, CommentDto>();
                    });
                    _initialized = true;
                }
            }
        }
    }
}
