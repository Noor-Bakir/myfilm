
using core;
using core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DataContext: DbContext
    {
        public DataContext (DbContextOptions<DataContext>options)
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
        }


        public DbSet<Film> Film { get; set; }
       

    }
    
}
