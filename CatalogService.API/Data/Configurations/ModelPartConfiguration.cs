using Microsoft.EntityFrameworkCore;
using CatalogService.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.API.Data.Configurations
{
    public class ModelPartConfiguration : IEntityTypeConfiguration<ModelPart>
    {
        public void Configure(EntityTypeBuilder<ModelPart> builder) 
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Type).IsRequired();
            builder.Property(p => p.SvgPath).IsRequired();
            builder.Property(p => p.LayerOrder).IsRequired();
        }
    }
}
