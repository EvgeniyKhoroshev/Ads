using Ads.CoreService.Contracts.Dto.Internal.Base;

namespace Ads.CoreService.Contracts.Dto
{
    public class ImageDto : Base
    {
        public string Content { get; set; }
        public int AdvertId { get; set; }
    }
}
