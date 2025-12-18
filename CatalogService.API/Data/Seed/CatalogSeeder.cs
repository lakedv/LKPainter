using CatalogService.API.Models;
using CatalogService.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.API.Data.Seed
{
    public static class CatalogSeeder
    {
        public static async Task SeedAsync(CatalogDbContext context)
        {
            await context.Database.MigrateAsync();
            if(!context.Models.Any())
            {
                var baseModel = new Model
                {
                    Id = Guid.NewGuid(),
                    Name = "Space Marine Base",
                    Faction = "Adeptus Astartes",
                    BaseSvgPath = "base/space_marine.svg",
                    IsBaseConcept = true,
                    CreatedAt = DateTime.UtcNow
                };

                context.Models.Add(baseModel);
            }

            if (!context.defaultLayerGroups.Any())
            {
                var layers = new List<DefaultLayerGroup>
                {
                    new DefaultLayerGroup { Id = Guid.NewGuid(), Name = "Base Armor", Order = 1 },
                    new DefaultLayerGroup { Id = Guid.NewGuid(), Name = "Details", Order = 2 },
                    new DefaultLayerGroup { Id = Guid.NewGuid(), Name = "Highlights", Order = 3 },
                    new DefaultLayerGroup { Id = Guid.NewGuid(), Name = "Weathering", Order = 4 },
                };

                context.defaultLayerGroups.AddRange(layers);
            }

            await context.SaveChangesAsync();
        }
    }
}
