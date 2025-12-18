namespace CatalogService.API.DTOs
{
    public class PartCompatibilityResponse
    {
        public Guid Id { get; set; }

        public Guid SourcePartId { get; set; }
        public string SourcePartName { get; set; } = default!;

        public Guid CompatibleWithPartId { get; set; }

        public string CompatibleWithPartName { get; set; } = default!;
    }
}
