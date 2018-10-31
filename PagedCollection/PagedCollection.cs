using System.Collections.Generic;

namespace Ads.Shared.Contracts
{
    /// <summary>
    /// Коллекция с поддержкой пагинации /
    /// Paginated collection
    /// </summary>
    /// <typeparam name="TItem">Тип объекта</typeparam>
    
    public class PagedCollection<TItem>
    {
        public PagedCollection(IReadOnlyCollection<TItem> items, int pageNumber, int pageSize, int totalPages)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = PageSize;
            TotalPages = totalPages;
        }

        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// Размер страницы.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Всего записей.
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Страничное отображение.
        /// </summary>
        public IReadOnlyCollection<TItem> Items { get; }
    }
}
