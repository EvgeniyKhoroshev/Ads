using Ads.CoreService.Contracts.Dto.Internal.Base;

namespace Ads.CoreService.Contracts.Dto
{
    public class CategoryDto : Base
    {
        /// <summary>
        /// Id родительской категории / Id of the parent category
        /// </summary> 
        public int? ParentCategoryId { get; set; }
    }
}