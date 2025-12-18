namespace CatalogService.API.Models
{
    public class PartCompatibility
    {
        public Guid Id { get; set; }

        public Guid SourcePartId { get; set; }
        public Guid CompatibleWithPartId { get; set; }

        public ModelPart SourcePart { get; set; } = default!;
        public ModelPart CompatibleWithPart { get; set; } = default!;
    }
}
