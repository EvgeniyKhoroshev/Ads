using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    class Status
    {
        /// <summary>
        /// Id статуса / status id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя статуса / Name of status
        /// </summary>
        public string Name { get; set; }
    }
}
