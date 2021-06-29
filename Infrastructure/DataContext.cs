using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Film>().HasData(
                new Film()
                {
                    Id = Guid.NewGuid(),
                    FilmDarg = "****",
                    FilmName = "Jungle",
                    // FilmImage = "~/image/Jungle.jpeg"
                }
                );
            modelBuilder.Entity<FilmStar1>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<FilmStar1>().HasData(
                new FilmStar1()
                {
                    Id = Guid.NewGuid(),
                    StarName = "alex",
                    Starimage = "~/img/image/Alex.jpg",
                    // FilmImage = "~/image/Jungle.jpeg"
                }
                );
            modelBuilder.Entity<FilmStar2>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }


        public DbSet<Film> Film { get; set; }
   
   
        public DbSet<FilmStar1> FilmStar1 { get; set; }
      
    }
}

