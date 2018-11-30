using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ThesisPrototype.DataModels;

namespace ThesisPrototype
{
    public class PrototypeContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Kpi> Kpis { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Do not embed plaintext connection strings in production, pls
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PrototypeDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(u => u.Vessels);
            modelBuilder.Entity<Ship>().HasOne(v => v.User);

            modelBuilder.Entity<Ship>().HasData
            (
                new
                {
                    ShipId = (long) 1,
                    UserId = (long) 1,
                    Name = "Waage",
                    ImageName = "ship1.jpg",
                    CountryName = "Germany",
                    ImoNumber = 1111111
                },
                new
                {
                    ShipId = (long) 2,
                    UserId = (long) 2,
                    Name = "Grüblein",
                    ImageName = "ship2.jpg",
                    CountryName = "Germany",
                    ImoNumber = 1111112
                },
                new
                {
                    ShipId = (long) 3,
                    UserId = (long) 3,
                    Name = "Schlauer Fuchs",
                    ImageName = "ship3.jpg",
                    CountryName = "Germany",
                    ImoNumber = 1111113
                },
                new
                {
                    ShipId = (long) 4,
                    UserId = (long) 3,
                    Name = "Mandritto",
                    ImageName = "ship4.jpg",
                    CountryName = "Italy",
                    ImoNumber = 1111114
                },
                new
                {
                    ShipId = (long) 5,
                    UserId = (long) 3,
                    Name = "Sottani",
                    ImageName = "ship5.jpg",
                    CountryName = "Italy",
                    ImoNumber = 1111115
                }
            );
        }
    }
}