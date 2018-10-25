using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Data.Repositories.Base
{
    public abstract class BaseRepository<T, Tid> : RepositoryInterfaces.Base.IRepositoryBase<T, int>
        where T : Entities.Base.BaseEntity
    {
        /// <summary>
        /// Контекст БД / DB context
        /// </summary>
        protected readonly AdsDBContext _dbContext;
        /// <summary>
        /// Конструктор без параметров для класса //
        /// Parametrless constructor
        /// </summary>
        /// <param name="dbContext"> Контекст БД // DB context</param>
        public BaseRepository(AdsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Получение сущности по идентификатору //
        /// Getting the entity by given id
        /// </summary>
        /// <param name="id"> Идентификатор сущности // Id of the entity</param>
        /// <returns>Сущность</returns>
        public virtual async Task<T> Get(int id)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            return result;
        }
        /// <summary>
        /// Перезаписывает сущность, если экземпляр с таким ID уже существует, в противном случае создает новую //
        /// Update the entity if the given T.Id already exists but create a new one if it`s not
        /// </summary>
        /// <param name="entity"> Сущность для перезаписи или создания //
        /// The entity for a rewrite or create</param>
        /// <returns>Возвращает Id созданной или обновленной сущности</returns>
        public virtual async Task<T> SaveOrUpdate(T entity)
        {
            try
            {
                if (await _dbContext.Set<T>().ContainsAsync(entity))
                {
                    _dbContext.Set<T>().Update(entity);
                    _dbContext.SaveChanges();
                }
                else
                {
                    _dbContext.Set<T>().Add(entity);
                    _dbContext.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                string error = "При создании/обновлении записи в базе произошла ошибка. " + ex.Message;
                throw new DbUpdateException(string.Join(Environment.NewLine, error), ex);
            }
            return entity;
        }

        /// <summary>
        /// Удаляет сущность из БД по заданному Id //
        /// Deleting the entity from DB by the given Id
        /// </summary>
        /// <param name="Id"> Id сущности // Entity Id</param>
        public virtual void Delete(int Id)
        {
            try
            {
                _dbContext.Set<T>().Remove(Get(Id).Result);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException("При удалении объявления № {Id} произошла ошибка. "
+ ex.Message);
            }
        }
        /// <summary>
        /// Получение всех записей из БД //
        /// Getting all entities from DB context 
        /// </summary>
        /// <returns>Список сущностей // List of an entity</returns>
        public virtual IQueryable<T> GetAll()
        {
            try
            { return _dbContext.Set<T>(); }
            catch (Exception ex)
            {
                throw new NullReferenceException("При попытке получить записи из БД произошла ошибка. " +
ex.Message);
            }
        }
    }
}
