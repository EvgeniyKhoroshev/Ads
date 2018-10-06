namespace Ads.Contracts.Dto
{
    public class AdvertsInfoDto
    {
        public AdvertType Types { get; set; }
        public Category Categories { get; set; }
        public City Cities { get; set; }
        public Status Statuses { get; set; }
        public Region Regions { get; set; }
    }
}
