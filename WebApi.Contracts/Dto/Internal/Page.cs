namespace Ads.Contracts.Dto.Internal
{
    public class Page<T>
    {
        public T PageSize { get; set; }
        public T PageNumber { get; set; }
    }
}