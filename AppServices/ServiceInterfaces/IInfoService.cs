using Ads.CoreService.Contracts.Dto;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces
{
    public interface IInfoService
    {
        Task<AdvertsInfoDto> GetInfoAsync();
        Task<CityDto[]> GetCitiesAsync(int? regionId);
        Task<CategoryDto[]> GetCategoriesAsync();
        Task<StatusDto[]> GetStatusesAsync();
        Task<AdvertTypeDto[]> GetTypesAsync();
        Task<RegionDto[]> GetRegionsAsync();
    }
}