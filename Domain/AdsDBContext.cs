using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class AdsDBContext : DbContext
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
            var ConnectionString ="Server=(localdb)\\MSSQLLocalDB;Database=Ads;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        //public AdsDBContext(DbContextOptions<AdsDBContext> options)
        //    : base(options)
        //{
        //    Database.EnsureCreated();
        //}

        public List<Advert> Include()
        {
            throw new NotImplementedException();
        }

    }
}
