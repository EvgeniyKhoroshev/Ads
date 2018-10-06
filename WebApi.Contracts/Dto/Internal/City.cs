namespace Ads.Contracts.Dto
{
    public class City
    {
        public int Id { get; set; }
        /// <summary>
        /// Id региона / region Id
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// Название города / City name
        /// </summary>
        public string Name { get; set; }
    }
}
