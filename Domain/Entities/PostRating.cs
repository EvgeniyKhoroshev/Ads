namespace Domain.Entities
{
    public class PostRating
    {
        /// <summary>
        /// Id пользователя, который оценил пост.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Id поста, который был оценен.
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// Принимает значение true если нравится пользователю и false - если не нравится.
        /// </summary>
        public bool IsRated { get; set; }
    }
}
