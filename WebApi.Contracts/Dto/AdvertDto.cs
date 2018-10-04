namespace Ads.Contracts.Dto
{
    public class AdvertDto
    {
        /// <summary>
        /// Название объявления / Advert name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание объявления / Ads description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Стопимость / Price
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Id cтатуca объявления / Id of a ads status
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Id категории, в которой находится объявление / 
        /// Id of the category in which that advert contains
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Id cтатуca объявления / Id of a ads status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Id типа объявления / Id of ads type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Id города / City id
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Id владельца объявления / Id of a ads owner
        /// Связь будет реализована после добавления MS Identity / 
        /// The relation will be implemented after the MS Identity added
        /// </summary>
        public int UserId { get; set; }
    }
}
