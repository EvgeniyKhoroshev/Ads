﻿using System.Collections.Generic;

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
        /// Возвращает список существующих элементов включая дочерние // 
        /// Returns all items including subsidiaries
        /// </summary>
        /// <returns>Возвращает список существующих элементов включая дочерние / 
        /// Returns all items including subsidiaries</returns>
        IList<T> GetAllWithIncludes();
        /// <summary>
        /// Возвращает список существующих элементов не включая дочерние // 
        /// Returns all items excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает список элементов / 
        /// Getting the items list</returns>
        IList<T> GetWithoutIncludes();
        /// <summary>
        /// Возвращает существующиq элемент включая дочерние // 
        /// Returns item including subsidiaries
        /// </summary>
        /// <returns>Возвращает существующий элемент включая дочерние / 
        /// Returns item including subsidiaries</returns>
        T GetWithIncludes(Tid Id);
        /// <summary>
        /// Возвращает существующий элемент не включая дочерние // 
        /// Returns item excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает элемент / 
        /// Getting the items list</returns>
        T GetWithoutIncludes(Tid Id);
        /// <summary>
        /// Сохраняет изменения или создает новый элемент, если такого не существует // 
        /// Save item or create if not exists
        /// </summary>
        /// <returns>Возвращает сохраненный или созданый элемент / 
        /// Returns the created or saved item</returns>
        T SaveOrUpdate(T entity);
        /// <summary>
        /// Функция для получения списка базовой информации
        /// The function to getting a list of a base information 
        /// </summary>
        /// <returns> Общую информацию для заполнения(отображения) объявлений / 
        /// Base infromation to entity filling </returns>
        T GetInfo();
    }
}
