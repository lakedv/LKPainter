using CatalogService.API.Models;

namespace CatalogService.API.DTOs
{
    public class ModelPartResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public PartType Type { get; set; }
        public string SvgPath { get; set; } = default!;
        public int LayerOrder { get; set; }
        public bool IsOptional { get; set; }

    }
}
