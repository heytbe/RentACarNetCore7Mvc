using Microsoft.EntityFrameworkCore;
using RentACar.Models;

namespace RentACar.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<CarImages> CarImages { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
