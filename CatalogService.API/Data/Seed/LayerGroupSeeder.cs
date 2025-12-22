using CatalogService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.API.Data.Seed
{
    public class LayerGroupSeeder
    {
        public static async Task SeedAsync(CatalogDbContext context, Guid modelId)
        {
            if (await context.LayerGroups.AnyAsync(lg => lg.ModelId == modelId))
                return;

            var groups = new List<LayerGroup>
            {
                CreateTorso(modelId),
                CreateArms(modelId),
                CreateLegs(modelId),
                CreateHelmet(modelId)
            };

            context.LayerGroups.AddRange(groups);
            await context.SaveChangesAsync();
        }

        private static LayerGroup CreateTorso(Guid modelId)
        {
            return new LayerGroup
            {
                Id = Guid.NewGuid(),
                ModelId = modelId,
                Name = "Torso",
                Code = "TORSO",
                Order = 1,
                Regions = new List<LayerRegion>
                {
                    Region("Chest Plate","TORSO_CHEST", 1),
                    Region("Aquila / Emblem", "TORSO_EMBLEM", 2, true),
                    Region("Abdomen", "TORSO_ABDOMEN", 3),
                    Region("Side Vents", "TORSO_VENTS", 4, true)
                }
            };
        }

        private static LayerGroup CreateArms(Guid modelId)
        {
            return new LayerGroup
            {
                Id = Guid.NewGuid(),
                ModelId = modelId,
                Name = "Arms",
                Code = "ARMS",
                Order = 2,
                Regions = new List<LayerRegion> 
                {
                    Region("Upper Arm","ARM_UPPER", 1),
                    Region("Elbow", "ARM_ELBOW", 2),
                    Region("Forearm", "ARM_FOREARM", 3),
                    Region("Gauntlet", "ARM_GAUNTLET", 4)
                }
            };
        }

        private static LayerGroup CreateLegs(Guid modelId)
        {
            return new LayerGroup
            {
                Id = Guid.NewGuid(),
                ModelId = modelId,
                Name = "Legs",
                Code = "LEGS",
                Order = 3,
                Regions = new List<LayerRegion>
                {
                    Region("Thigh","LEG_THIGH", 1),
                    Region("Knee Pad", "LEG_KNEE", 2),
                    Region("Shin", "LEG_SHIN", 3),
                    Region("Foot", "LEG_FOOT", 4)
                }
            };
        }

        private static LayerGroup CreateHelmet(Guid modelId)
        {
            return new LayerGroup
            {
                Id = Guid.NewGuid(),
                ModelId = modelId,
                Name = "Helmet",
                Code = "HELMET",
                Order = 4,
                Regions = new List<LayerRegion>
                {
                    Region("Helmet Shell","HELMET_SHELL", 1),
                    Region("Faceplate", "HELMET_FACE", 2),
                    Region("Eye / Lenses", "HELMET_EYES", 3, true)
                }
            };
        }

        private static LayerRegion Region(
            string name,
            string code,
            int order,
            bool optional = false)
        {
            return new LayerRegion
            {
                Id = Guid.NewGuid(),
                Name = name,
                Code = code,
                Order = order,
                IsOptional = optional,
                SvgMaskPath = $"masks/{code.ToLower()}.svg"
            };
        }
    }
}
