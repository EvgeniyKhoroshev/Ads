using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data.Repositories
{
    public class AdvertRepository : Base.BaseRepository<Advert, int>
    {
        readonly AdsDBContext _dbContext;
        public AdvertRepository(AdsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override Advert Get(int id)
        {
            Advert result = _dbContext
                                .Adverts
                                .FirstOrDefaultAsync(x => x.Id == id)
                                .Result;
            return result;
        }
        public override Advert New(Advert entity)
        {
            _dbContext.Adverts.Add(entity);
            _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
