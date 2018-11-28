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
        readonly IPostRatingRepository _postRatingRepository;
        readonly IAdvertInfoRepository<AdvertsInfo, int> _infoRepository;
        public InfoService(IAdvertInfoRepository<AdvertsInfo, int> infoRepository,
                           IPostRatingRepository postRatingRepository)
        {
            _postRatingRepository = postRatingRepository;
            _infoRepository = infoRepository;
        }
        /// <inheritdoc />
        public async Task<CategoryDto[]> GetCategoriesAsync()
        {
            var categories = await _infoRepository.GetCategoriesAsync();
            return Mapper.Map<CategoryDto[]>(categories);
        }

        /// <inheritdoc />
        public async Task<CityDto[]> GetCitiesAsync(int? regionId)
        {
            var cities = await _infoRepository.GetCitiesAsync(regionId);
            return Mapper.Map<CityDto[]>(cities);
        }

        /// <inheritdoc />
        public async Task<AdvertsInfoDto> GetInfoAsync()
        {
            AdvertsInfo info = await _infoRepository.GetAllAsync();
            return Mapper.Map<AdvertsInfoDto>(info);
        }

        /// <inheritdoc />
        public async Task<RegionDto[]> GetRegionsAsync()
        {
            var regions = await _infoRepository.GetRegionsAsync();
            return Mapper.Map<RegionDto[]>(regions);
        }
        /// <inheritdoc />
        public async Task<StatusDto[]> GetStatusesAsync()
        {
            var statuses = await _infoRepository.GetStatussesAsync();
            return Mapper.Map<StatusDto[]>(statuses);
        }
        /// <inheritdoc />
        public async Task<AdvertTypeDto[]> GetTypesAsync()
        {
            var types = await _infoRepository.GetTypesAsync();
            return Mapper.Map<AdvertTypeDto[]>(types);
        }
    }
}
