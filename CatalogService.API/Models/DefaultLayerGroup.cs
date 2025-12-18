namespace CatalogService.API.Models
{
    public class DefaultLayerGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Order { get; set; }
    }
}
