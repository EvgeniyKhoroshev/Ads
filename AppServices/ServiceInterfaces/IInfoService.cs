using Ads.CoreService.Contracts.Dto;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces
{
    public interface IInfoService
    {
        /// <summary>
        /// Функция для получения всех метаданных
        /// </summary>
        /// <returns>Структуру со всеми метаданными о объявлениях</returns>
        Task<AdvertsInfoDto> GetInfoAsync();
        /// <summary>
        /// Возвращает список всех городов, если <paramref name="regionId"/> == null, 
        /// иначе - возвращает все города <paramref name="regionId"/> региона
        /// </summary>
        /// <param name="regionId">Id Региона</param>
        /// <returns>Список городов</returns>
        Task<CityDto[]> GetCitiesAsync(int? regionId);
        /// <summary>
        /// Возвращает список категорий
        /// </summary>
        /// <returns>Список категорий</returns>
        Task<CategoryDto[]> GetCategoriesAsync();
        /// <summary>
        /// Возвращает возможные статусы объявления
        /// </summary>
        /// <returns>Список статусов объявления</returns>
        Task<StatusDto[]> GetStatusesAsync();
        /// <summary>
        /// Возвращает список возможных типов объявлений
        /// </summary>
        /// <returns>Список типов</returns>
        Task<AdvertTypeDto[]> GetTypesAsync();
        /// <summary>
        /// Возвращает все регионы
        /// </summary>
        /// <returns>Список регионов</returns>
        Task<RegionDto[]> GetRegionsAsync();
        

    }
}