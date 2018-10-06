namespace Domain.Entities
{
    public class AdvertsInfo : Entities.Base.EntityWithTypedIdBase<int>
    {
        public AdvertType Types { get; set; }
        public Category Categories { get; set; }
        public City Cities { get; set; }
        public Status Statuses { get; set; }
        public Region Regions { get; set; }
    }
}
