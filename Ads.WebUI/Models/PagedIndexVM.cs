using Ads.Contracts.Dto.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Models
{
    public class PagedIndexVM
    {
        public AdsVMIndex[] Adverts { get; set; }
        public Page Page { get; set; }
    }
}
