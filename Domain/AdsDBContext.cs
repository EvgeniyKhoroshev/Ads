using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class AdsDBContext : DbContext
    {

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Status> Statuses{ get; set; }
        public DbSet<AdvertType> AdvertTypes { get; set; }

        public AdsDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = DBConfig.DB_DEFAULT_CONNECTION_STRING;
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public List<Advert> Include()
        {
            throw new NotImplementedException();
        }

    }
}
