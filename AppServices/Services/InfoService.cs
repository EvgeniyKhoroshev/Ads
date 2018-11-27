using Ads.CoreService.Contracts.Dto;
using AppServices.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System.Threading.Tasks;

namespace Ads.CoreService.AppServices.Services
{
    public class InfoService : IInfoService
    {
        readonly IAdvertInfoRepository<AdvertsInfo, int> _infoRepository;
        public InfoService(IAdvertInfoRepository<AdvertsInfo, int> infoRepository)
        {
            _infoRepository = infoRepository;
        }

        public async Task<CategoryDto[]> GetCategoriesAsync()
        {
            var categories = await _infoRepository.GetCategoriesAsync();
            return Mapper.Map<CategoryDto[]>(categories);
        }


        public async Task<CityDto[]> GetCitiesAsync(int? regionId)
        {
            var cities = await _infoRepository.GetCitiesAsync(regionId);
            return Mapper.Map<CityDto[]>(cities);
        }
        public async Task<AdvertsInfoDto> GetInfoAsync()
        {
            AdvertsInfo info = await _infoRepository.GetAllAsync();
            return Mapper.Map<AdvertsInfoDto>(info);
        }

        public async Task<RegionDto[]> GetRegionsAsync()
        {
            var regions = await _infoRepository.GetRegionsAsync();
            return Mapper.Map<RegionDto[]>(regions);
        }

        public async Task<StatusDto[]> GetStatusesAsync()
        {
            var statuses = await _infoRepository.GetStatussesAsync();
            return Mapper.Map<StatusDto[]>(statuses);
        }

        public async Task<AdvertTypeDto[]> GetTypesAsync()
        {
            var types = await _infoRepository.GetTypesAsync();
            return Mapper.Map<AdvertTypeDto[]>(types);
        }
    }
}
