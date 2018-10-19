using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.Data.Repositories
{
    public class CommentsRepository : Base.BaseRepository<Comment, int>, ICommentsRepository
    {
        /// <summary>
        /// Переменная контекста базы данных // 
        /// Variable of database context
        /// </summary>
        public CommentsRepository(AdsDBContext dbContext) : base(dbContext) { }

    }
}
