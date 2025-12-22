namespace CatalogService.API.Models
{
    public class LayerGroup
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }

        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public int Order { get; set; }

        public ICollection<LayerRegion> Regions { get; set; } = new List<LayerRegion>();
    }
}
