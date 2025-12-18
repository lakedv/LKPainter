namespace CatalogService.API.Models
{
    public class Model
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Faction { get; set; } = default!;
        public string BaseSvgPath { get; set; } = default!;
        public bool IsBaseConcept { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        
        public ICollection<ModelPart> Parts { get; set; } = new List<ModelPart>();
        public ICollection<PartCompatibility> PartCompatibilities { get; set; } = new List<PartCompatibility>();
        public ICollection<DefaultLayerGroup> DefaultLayerGroups { get; set; } = new List<DefaultLayerGroup>();
    }
}