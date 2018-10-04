using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    class Type
    {
        /// <summary>
        /// Id объявления / Tipe Id
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// Название типа / Name of advert type
        /// </summary>
        public string AdvertType { get; set; }
    }
}
