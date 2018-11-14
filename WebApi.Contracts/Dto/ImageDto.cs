using System;
using System.Collections.Generic;
using System.Text;

namespace Ads.CoreService.Contracts.Dto
{
    public class ImageDto : Internal.Base.Base
    {
        public string Content { get; set; }
        public int AdvertId { get; set; }
        public int DefaultId { get; set; }
        public ImageDto()
        {
            DefaultId = 1;
        }
    }
}
