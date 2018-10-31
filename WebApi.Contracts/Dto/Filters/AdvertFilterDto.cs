using Ads.Shared.Contracts;
namespace Ads.CoreService.Contracts.Dto.Filters
{
    public class AdvertFilterDto : PaginationFilterDto
    {
        /// <summary>
        /// Идентификатор региона для поиска /
        /// Region id for searching
        /// </summary>
        public int? RegionId { get; set; }
        /// <summary>
        /// Идентификатор города для поиска /
        /// City id for searching
        /// </summary>
        public int? CityId { get; set; }
        /// <summary>
        /// Подстрока для поиска по тексту или названию объявления /
        /// Substring for searching by the text or title of advert
        /// </summary>
        public string Substring { get; set; }
        /// <summary>
        /// Идентификатор категории для поиска /
        /// Category id for searching
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// Диапазон цен для фильтрации /
        /// Price range for a filtration
        /// </summary>
        public InclusiveRange<decimal?> PriceRange { get; set; }
    }
}
