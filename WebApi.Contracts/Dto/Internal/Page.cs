namespace Ads.Contracts.Dto.Internal
{
    public class Page
    {
        public Page()
        {
            PageSize = 2;
            PageNumber = 1;
        }
        public Page(int pageSize)
        {
            PageSize = pageSize;
            PageNumber = 1;
        }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}