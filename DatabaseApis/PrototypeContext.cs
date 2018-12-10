using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.DatabaseApis
{
    /// <summary>
    /// The context implementation used for calls to the Entity Framework. 
    /// Inherits from IdentityDbContext, which provides the DbSet for the 'User' entity.
    /// </summary>
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
        }
    }
}