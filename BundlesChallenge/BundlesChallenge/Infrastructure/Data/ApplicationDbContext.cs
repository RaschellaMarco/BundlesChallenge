using Microsoft.EntityFrameworkCore;

namespace BundlesChallenge.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<BundleEntity> Bundles { get; set; }
        public DbSet<BundleItem> BundleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new BundleConfiguration());
            modelBuilder.ApplyConfiguration(new BundleItemConfiguration());
          
        }
    }
}

