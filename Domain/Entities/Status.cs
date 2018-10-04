using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    class Status : EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Имя статуса / Name of status
        /// </summary>
        public string Name { get; set; }
    }
}
