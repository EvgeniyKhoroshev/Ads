using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IAdvertInfoRepository<T, Tid>
    {
        //<inheritdoc>
        Task<Category[]> GetCategoriesAsync();
        //<inheritdoc>
        Task<AdvertType[]> GetTypesAsync();
        //<inheritdoc>
        Task<Status[]> GetStatussesAsync();
        //<inheritdoc>
        Task<Region[]> GetRegionsAsync();
        //<inheritdoc>
        Task<AdvertsInfo> GetAllAsync();
        //<inheritdoc>
        Task<City[]> GetCitiesByRegionIdAsync(int? regionId);
        //<inheritdoc>
        Task<City> GetCityByIdAsync(int id);

    }
}
