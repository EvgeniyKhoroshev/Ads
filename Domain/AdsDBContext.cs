using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    class AdsDBContext : DbContext
    {

        public DbSet<Advert>

        public AdsDBContext(DbContextOptions<AdsDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        
    }
}
