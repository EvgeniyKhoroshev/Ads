namespace Ads.Contracts.Dto
{
    public class Status
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя статуса / Name of status
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Многие-ко-одному свзязь к объявлениям / Many-to-one relation to adverts
        /// </summary> 
    }
}
