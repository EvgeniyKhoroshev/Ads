using Ads.Contracts.Dto.Internal;

namespace Ads.Contracts.Dto.Filters
{
    public class FilterDto
    {
        public FilterDto()
        {
            PriceRange = new Range<decimal?>();
            Pagination = new Page();
        }
        public Page Pagination { get; set; }
        public Range<decimal?> PriceRange { get; set; }
        public int? CategoryId { get; set; }
        public int? RegionId { get; set; }
        public int? CityId { get; set; }
        public string Substring { get; set; }

    }
}
