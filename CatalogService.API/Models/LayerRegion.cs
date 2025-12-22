namespace CatalogService.API.Models
{
    public class LayerRegion
    {
        public Guid Id { get; set; }
        public Guid LayerGroupId { get; set; }

        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public bool IsOptional { get; set; } = true;

        public string SvgMaskPath { get; set; } = default!;
        public int Order { get; set; }

        public LayerGroup LayerGroup { get; set; }
    }
}
