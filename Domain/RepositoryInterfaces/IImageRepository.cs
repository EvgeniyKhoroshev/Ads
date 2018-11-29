using Domain.Entities;
using Domain.RepositoryInterfaces.Base;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IImageRepository : IRepositoryBase<Image, int>
    {
        /// <summary>
        /// Удаляет все изображения объявления с id = <paramref name="advertId"/>
        /// </summary>
        /// <param name="advertId">Id объявления</param>
        /// <returns>Флаг успешности выполнения операции.</returns>
        Task<bool> DeleteAdvertImages(int advertId);
        /// <summary>
        /// Возвращает изображения объявления с id = <paramref name="advertId"/>
        /// </summary>
        /// <param name="advertId">Id объявления</param>
        /// <returns>Список изображений</returns>
        Task<Image[]> GetAdvertImages(int advertId);
    }
}
