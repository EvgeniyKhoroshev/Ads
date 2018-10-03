namespace Domain.Entities.Base
{
    public abstract class EntityWithTypedIdBase<TId>
    {
        /// <summary>
        /// Идентификатор / Identifier
        /// </summary>
        public virtual TId Id { get; protected set; }
    }
}
