namespace Domain.Entities.Base
{
    public abstract class EntityWithTypedIdBase<TId>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual TId Id { get; protected set; }
    }
}
