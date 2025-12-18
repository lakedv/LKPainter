using CatalogService.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DefaultLayerGroupConfiguration : IEntityTypeConfiguration<DefaultLayerGroup>
{
    public void Configure(EntityTypeBuilder<DefaultLayerGroup> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name).IsRequired();
        builder.Property(d => d.Order).IsRequired();
    }
}