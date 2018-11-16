using Ads.Shared.Domain.Abstractions;
using System;

namespace Domain.Entities
{
    public class Image : BaseEntity
    {
        public new DateTime? Created { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}
