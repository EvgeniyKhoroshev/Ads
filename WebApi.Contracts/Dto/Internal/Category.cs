namespace Ads.Contracts.Dto
{
    public class Category
    {
        public int Id { get; set; }
        /// <summary>
        /// Название категории / Name of category
        /// </summary> 
        public string Name { get; set; }
        /// <summary>
        /// Id родительской категории / Id of the parent category
        /// </summary> 
        public int? ParentCategoryId { get; set; }
    }
}