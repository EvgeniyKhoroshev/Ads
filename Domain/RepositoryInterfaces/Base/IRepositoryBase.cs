using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces.Base
{
    public interface IRepositoryBase<T, Tid> where  T : Entities.Base.EntityWithTypedIdBase<Tid>
    {
        /// <summary>
        /// Удаление сущности по Id // 
        /// Deleting an entity by Id
        /// </summary>
        /// <param name="id">Идентификатор сущности / Id of entity</param>
        void Delete(Tid Id);
        /// <summary>
        /// Сохраняет изменения или создает новый элемент, если такого не существует // 
        /// Save item or create if not exists
        /// </summary>
        /// <returns>Возвращает сохраненный или созданый элемент / 
        /// Returns the created or saved item</returns>
        Task<T> SaveOrUpdate(T entity);
        /// <summary>
        /// Функция для получения списка базовой информации
        /// The function to getting a list of a base information 
        /// </summary>
        /// <returns> Общую информацию для заполнения(отображения) объявлений / 
        /// Base infromation to entity filling </returns>
        IQueryable<T> GetAll();
    }
}
