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
        }

        public Range<decimal?> PriceRange { get; set; }
        public int? CategoryId { get; set; }
        public int? RegionId { get; set; }
        public int? CityId { get; set; }
        public string Substring { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
