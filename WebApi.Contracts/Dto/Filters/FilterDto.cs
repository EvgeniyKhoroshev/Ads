using System;
using System.Collections.Generic;
using System.Text;

namespace Ads.Contracts.Dto.Filters
{
    public class FilterDto
    {
        public Range<decimal?> PriceRange { get; set; }

        public string Category { get; set; }
    }

    public class Range<T>
    {
        public T MinValue { get; set; }

        public T MaxValue { get; set; }
    }
}
