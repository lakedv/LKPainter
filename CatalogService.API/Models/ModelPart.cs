namespace CatalogService.API.Models
{
    public class ModelPart
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }

        public string Name { get; set; } = default!;
        public PartType Type { get; set; } 

        public string SvgPath { get; set; } = default!;
        public int LayerOrder { get; set; }
        public bool isOptional { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Model Model { get; set; } = default!;
    }
}
