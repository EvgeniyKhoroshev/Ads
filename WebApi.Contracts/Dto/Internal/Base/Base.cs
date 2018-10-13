using System;
using System.Collections.Generic;
using System.Text;

namespace Ads.Contracts.Dto.Internal.Base
{
    public abstract class Base
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Названи
        /// </summary> 
        public string Name { get; set; }
    }
}
