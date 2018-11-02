using Ads.Shared.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Data.Repositories.Base
{
    public abstract class BaseRepository<T, Tid> : RepositoryInterfaces.Base.IRepositoryBase<T, int>
        where T : BaseEntity
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
        public virtual async Task<T> GetAsync(int id)
        {
            try
            {
                var result = await _dbContext.Set<T>()
                    .FirstOrDefaultAsync(t => t.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                string error = "При попытке получить запись из БД произошла ошибка. " + ex.Message;
                throw new NullReferenceException(string.Join(Environment.NewLine, error), ex);
            }
        }
        /// <summary>
        /// Перезаписывает сущность, если экземпляр с таким ID уже существует, в противном случае создает новую //
        /// Update the entity if the given T.Id already exists but create a new one if it`s not
        /// </summary>
        /// <param name="entity"> Сущность для перезаписи или создания //
        /// The entity for a rewrite or create</param>
        /// <returns>Возвращает Id созданной или обновленной сущности</returns>
        public virtual async Task<T> SaveOrUpdateAsync(T entity)
        {
            try
            {
                if (await _dbContext.Set<T>().ContainsAsync(entity))
                {
                    _dbContext.Set<T>().Update(entity);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    _dbContext.Set<T>().Add(entity);
                    await _dbContext.SaveChangesAsync();
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
                _dbContext.Set<T>().Remove(GetAsync(Id).Result);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                string error = "При удалении записи из базы произошла ошибка. " + ex.Message;
                throw new DbUpdateException(string.Join(Environment.NewLine, error), ex);
            }
        }
        /// <summary>
        /// Получение всех записей из БД //
        /// Getting all entities from DB context 
        /// </summary>
        /// <returns>Список сущностей // List of an entity</returns>
        public virtual IQueryable<T> GetAll()
        {
            try { return _dbContext.Set<T>(); }
            catch (Exception ex)
            {
                string error = "При создании запроса к БД произошла ошибка. " + ex.Message;
                throw new NullReferenceException(string.Join(Environment.NewLine, error), ex);
            }
        }
    }
}
