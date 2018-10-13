using Ads.Contracts.Dto.Internal.Base;

namespace Ads.Contracts.Dto
{
    public class Category : Base
    {
        /// <summary>
        /// Id родительской категории / Id of the parent category
        /// </summary> 
        public int? ParentCategoryId { get; set; }
    }
}