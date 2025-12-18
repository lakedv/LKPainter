namespace CatalogService.API.DTOs
{
    public class ModelResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Faction { get; set; } = default!;
        public string BaseSvgPath { get; set; } = default!;
        public bool IsBaseConcept {  get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
