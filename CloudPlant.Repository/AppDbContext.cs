using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.Identity;
using Microsoft.EntityFrameworkCore;


namespace CloudPlant.Repository
{

        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Device> Devices { get; set; }
            public DbSet<Measurement> Measurements { get; set; }
            public DbSet<Plant> Plants { get; set; }
            public DbSet<PlantType> PlantTypes { get; set; }
            public DbSet<CloudPlantUser> CloudPlantUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            }
        }
}
