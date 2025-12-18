namespace CatalogService.API.DTOs
{
    public class ModelUpdateRequest
    {
        public string Name { get; set; } = default!;
        public string Faction { get; set; } = default!;
        public string BaseSvgPath { get; set; } = default!;

    }
}
