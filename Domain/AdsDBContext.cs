using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Domain
{
    public class AdsDBContext : IdentityDbContext<User,
        IdentityRole<int>,
        int, IdentityUserClaim<int>,
        IdentityUserRole<int>,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {

        public AdsDBContext(DbContextOptions<AdsDBContext> options) : base(options)
        {
        }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<AdvertType> AdvertTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(t =>
            {
                t.ToTable("Users");
                t.Ignore(user => user.TwoFactorEnabled);
                t.Ignore(user => user.ConcurrencyStamp);
                t.Ignore(user => user.LockoutEnabled);
                t.Ignore(user => user.LockoutEnd);
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });
            builder.Entity<Image>(t =>
            {
                t.Property(x => x.Id)
                .UseSqlServerIdentityColumn();
                t.Property(x => x.DefaultId)
                .HasDefaultValue(1);
            });
            builder.Entity<Comment>()
                .Property(t => t.Id)
                .UseSqlServerIdentityColumn();
            builder.Entity<Advert>()
                .HasMany(t => t.Comments)
                .WithOne(t => t.Advert)
                .HasForeignKey(t => t.AdvertId);
            builder.Entity<Advert>()
                .HasMany(t => t.Images)
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

        }
        //public AdsDBContext()
        //{
        //    Database.EnsureCreated();
        //}       
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Ads;Trusted_Connection=True;MultipleActiveResultSets=true");

        //}
    }
}
