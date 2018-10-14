using Ads.Contracts.Dto.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ads.Contracts.Dto.Filters
{
    public class FilterDto
    {
        public FilterDto()
        {
            PriceRange = new Range<decimal?>();
            Pagination = new Page<int> { PageSize = 5, PageNumber = 1 };
        }
        public Page<int> Pagination { get; set; }
        public Range<decimal?> PriceRange { get; set; }
        public int? CategoryId { get; set; }
        public int? RegionId { get; set; }
        public int? CityId { get; set; }
        public string Substring { get; set; }

    }
}
