using Domain.Entities;
using Domain.RepositoryInterfaces.Base;

namespace Domain.RepositoryInterfaces
{
    public interface ICommentsRepository : IRepositoryBase<Comment, int>
    {
    }
}
