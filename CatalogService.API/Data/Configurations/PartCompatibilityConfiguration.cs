using Microsoft.EntityFrameworkCore;
using CatalogService.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.API.Data.Configurations
{
    public class PartCompatibilityConfiguration : IEntityTypeConfiguration<PartCompatibility>
    {
        public void Configure(EntityTypeBuilder<PartCompatibility> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.HasOne(pc => pc.SourcePart)
                .WithMany()
                .HasForeignKey(pc => pc.SourcePartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.CompatibleWithPart)
                .WithMany()
                .HasForeignKey(pc => pc.CompatibleWithPartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
