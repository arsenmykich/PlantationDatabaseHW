using databaseHempPlantations.Models;
using Microsoft.EntityFrameworkCore;
namespace HempPlantationsDatabase.Models
{
    public class PlantationContext : DbContext
    {
        public DbSet<Agronomist> Agronomists { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<HempVariety> HempVarieties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Harvest> Harvests { get; set; }
        public DbSet<Tasting> Tastings { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<HarvestProduct> HarvestProducts { get; set; }
        public DbSet<TastingReview> TastingReviews { get; set; }
        public DbSet<TravelAssignment> TravelAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public PlantationContext(DbContextOptions<PlantationContext> options):
            base(options)
        {
            Database.EnsureCreated();
        }
    }
}
