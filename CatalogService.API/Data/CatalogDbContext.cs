using Microsoft.EntityFrameworkCore;
using CatalogService.API.Data.Configurations;
using CatalogService.API.Models;
using CatalogService.API.Data.Seed;

namespace CatalogService.API.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) 
        {
        }

        public DbSet<Model> Models => Set<Model>();
        public DbSet<ModelPart> ModelParts => Set<ModelPart>();
        public DbSet<PartCompatibility> partCompatibilities => Set<PartCompatibility>();
        public DbSet<DefaultLayerGroup> defaultLayerGroups => Set<DefaultLayerGroup>();
        public DbSet<LayerGroup> LayerGroups => Set<LayerGroup>();
        public DbSet<LayerRegion> LayerRegions => Set<LayerRegion>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new ModelPartConfiguration());
            modelBuilder.ApplyConfiguration(new PartCompatibilityConfiguration());
            modelBuilder.ApplyConfiguration(new DefaultLayerGroupConfiguration());
        }
    }
}