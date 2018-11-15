using Domain.Data.Repositories.Base;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.Data.Repositories
{
    public class ImageRepository : BaseRepository<Image,int>, IImageRepository
    {
        public ImageRepository(AdsDBContext dbContext) : base(dbContext) { }

    }
}
