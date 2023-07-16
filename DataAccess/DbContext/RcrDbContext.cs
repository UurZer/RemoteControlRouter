using Microsoft.EntityFrameworkCore;
using Rcr.Data.DbModelConfiguration;
using Rcr.Data.Entity;

namespace Rcr.DataAccess.Context
{
    public class RcrDbContext : DbContext
    {
        public RcrDbContext(DbContextOptions<RcrDbContext> options)
        : base(options)
        {
        }

        public RcrDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
            .HasOne(x => x.Route);
            

            modelBuilder.AddConfiguration(new VehicleDbMapper());
            modelBuilder.AddConfiguration(new RouteDbMapper());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("RcrDbContext");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleRoute> Route { get; set; }
    }
}
