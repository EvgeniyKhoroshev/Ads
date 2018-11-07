using System;
using System.Collections.Generic;
using System.Text;

namespace Ads.Shared.Contracts
{
    /// <summary>
    /// Фильтр с пагинацией / 
    /// Paginated filter
    /// </summary>
    public abstract class PaginationFilterDto
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize { get; set; }

        public PaginationFilterDto()
        {
            PageNumber = 1;
            PageSize = 9;
        }
    }
}
