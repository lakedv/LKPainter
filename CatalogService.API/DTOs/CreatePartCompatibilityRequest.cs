namespace CatalogService.API.DTOs
{
    public class CreatePartCompatibilityRequest
    {
        public Guid SourcePartId { get; set; }
        public Guid CompatibleWithPartId { get; set; }
    }
}
