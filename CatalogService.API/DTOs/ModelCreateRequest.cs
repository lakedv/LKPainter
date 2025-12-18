namespace CatalogService.API.DTOs
{
    public class ModelCreateRequest
    {
        public string Name { get; set; } = default!;
        public string Faction { get; set; } = default!;
        public string BaseSvgPath { get; set; } = default!;
        public bool IsBaseConcept { get; set; }
    }
}
