using Ads.Shared.Domain.Abstractions;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AdvertsInfo : EntityWithTypedIdBase<int>
    {
        public IList<AdvertType> Types { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<City> Cities { get; set; }
        public IList<Status> Statuses { get; set; }
        public IList<Region> Regions { get; set; }
    }
}
