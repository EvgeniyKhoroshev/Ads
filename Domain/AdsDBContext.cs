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
        public DbSet<Status> Statuses { get; set; }
        public DbSet<AdvertType> AdvertTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>()
                .Property(t => t.Id)
                .UseSqlServerIdentityColumn();
            builder.Entity<Advert>()
                .HasMany(t => t.Comments)
                .WithOne(t => t.Advert)
                .HasForeignKey(t => t.AdvertId);
            builder.Entity<City>()
                .HasOne(t => t.Region)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<City>()
                .Property(t => t.Id)
                .UseSqlServerIdentityColumn();
            builder.Entity<Region>()
                .Property(t => t.Id)
                .UseSqlServerIdentityColumn();
            builder.Entity<Category>()
                .Property(t => t.Id)
                .UseSqlServerIdentityColumn();
            builder.Entity<Advert>()
                .Property(t => t.Id)
                .UseSqlServerIdentityColumn();
            builder.Entity<Status>()
                .Property(t => t.Id)
                .UseSqlServerIdentityColumn();
            builder.Entity<AdvertType>()
                .Property(t => t.Id)
                .UseSqlServerIdentityColumn();
            builder.Entity<Advert>()
                .HasOne(t => t.Type)
                .WithMany(c => c.Adverts)
                .HasForeignKey(c => c.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Advert>()
                .HasOne(t => t.Status)
                .WithMany(c => c.Adverts)
                .HasForeignKey(c => c.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Advert>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Adverts)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Advert>()
                .HasOne(t => t.City)
                .WithMany(c => c.Adverts)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);

        }

        public AdsDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = DBConfig.DB_DEFAULT_CONNECTION_STRING;
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
