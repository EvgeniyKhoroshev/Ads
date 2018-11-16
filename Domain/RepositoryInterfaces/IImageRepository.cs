using Domain.Entities;
using Domain.RepositoryInterfaces.Base;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IImageRepository : IRepositoryBase<Image, int>
    {
    }
}
