using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.Data.Repositories
{
    public class AdvertRepository : Base.BaseRepository<Advert, int>, IAdvertRepository
    {
        public AdvertRepository(AdsDBContext dbContext) : base(dbContext) { }
    }

}