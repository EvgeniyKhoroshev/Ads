﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ads.CoreService.Contracts.Dto.Internal
{
    public class Range<T>
    {
        public T MinValue { get; set; }

        public T MaxValue { get; set; }
    }
}
