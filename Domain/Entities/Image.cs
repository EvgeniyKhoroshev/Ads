using Ads.Shared.Domain.Abstractions;

namespace Domain.Entities
{
    public class Image : EntityWithTypedIdBase<int>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}
