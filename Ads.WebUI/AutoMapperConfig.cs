using Ads.Contracts.Dto;
using Ads.WebUI.Models;
using AutoMapper;

namespace Ads.WebUI
{
    public class WebUIAutoMapperConfig
    {
        public static void Initialize()
        {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<AdvertDto, AdsVMIndex>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<AdsVMIndex, AdvertDto>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            });
        }
    }
}
