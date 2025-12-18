using CatalogService.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.API.Data.Configurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Faction).IsRequired().HasMaxLength(50);
            builder.Property(m => m.BaseSvgPath).IsRequired();

            builder.HasMany(m => m.Parts)
                .WithOne(p => p.Model)
                .HasForeignKey(p => p.ModelId);

            builder.HasMany(m => m.PartCompatibilities)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
