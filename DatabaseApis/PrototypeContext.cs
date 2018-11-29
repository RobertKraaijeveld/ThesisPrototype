using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ThesisPrototype
{
    public class PrototypeContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vessel> Vessels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Do not embed plaintext connection strings in production, pls
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PrototypeDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(u => u.Vessels);
            modelBuilder.Entity<Vessel>().HasOne(v => v.User);

            modelBuilder.Entity<Vessel>().HasData
            (
                new
                {
                    VesselId = (long) 1,
                    UserId = (long) 1,
                    Name = "Waage",
                    ImageName = "ship1.jpg",
                    CountryName = "Germany",
                    ImoNumber = 1111111
                },
                new
                {
                    VesselId = (long) 2,
                    UserId = (long) 2,
                    Name = "Grüblein",
                    ImageName = "ship2.jpg",
                    CountryName = "Germany",
                    ImoNumber = 1111112
                },
                new
                {
                    VesselId = (long) 3,
                    UserId = (long) 3,
                    Name = "Schlauer Fuchs",
                    ImageName = "ship3.jpg",
                    CountryName = "Germany",
                    ImoNumber = 1111113
                },
                new
                {
                    VesselId = (long) 4,
                    UserId = (long) 3,
                    Name = "Mandritto",
                    ImageName = "ship4.jpg",
                    CountryName = "Italy",
                    ImoNumber = 1111114
                },
                new
                {
                    VesselId = (long) 5,
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