using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class InfoService : IInfoService
    {
        readonly IAdvertInfoRepository _infoRepository;
        public InfoService(IAdvertInfoRepository infoRepository)
        {
            _infoRepository = infoRepository;
        }

        public async Task<AdvertsInfoDto> GetInfo()
        {
            AdvertsInfo info = await _infoRepository.GetInfo();
            return AutoMapper.Mapper.Map<AdvertsInfoDto>(info);
        }


    }
}
