using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.DatabaseApis
{
    public class PrototypeContext : IdentityDbContext<User>
    {
        public DbSet<Ship> Ships { get; set; }
        public DbSet<DataImportMeta> DataImportMetas { get; set; }
        public DbSet<Kpi> Kpis { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Do not embed plaintext connection strings in production, pls
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PrototypeDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ship>().HasOne<User>(x => x.User);

            modelBuilder.Entity<Ship>().HasData
            (
                new Ship
                {
                    ShipId = 1,
                    UserId = 1,
                    Name = "Waage",
                    ImageName = "ship1.jpg",
                    CountryName = "Germany",
                    ImoNumber = 1111111
                },
                new Ship
                {
                    ShipId = 2,
                    UserId = 2,
                    Name = "Grüblein",
                    ImageName = "ship2.jpg",
                    CountryName = "Germany",
                    ImoNumber = 1111112
                },
                new Ship
                {
                    ShipId = 3,
                    UserId = 3,
                    Name = "Schlauer Fuchs",
                    ImageName = "ship3.jpg",
                    CountryName = "Germany",
                    ImoNumber = 1111113
                },
                new Ship
                {
                    ShipId = 4,
                    UserId = 3,
                    Name = "Mandritto",
                    ImageName = "ship4.jpg",
                    CountryName = "Italy",
                    ImoNumber = 1111114
                },
                new Ship
                {
                    ShipId = 5,
                    UserId = 3,
                    Name = "Sottani",
                    ImageName = "ship5.jpg",
                    CountryName = "Italy",
                    ImoNumber = 1111115
                }
            );
        }
    }
}