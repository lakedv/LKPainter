using CatalogService.API.Models;

namespace CatalogService.API.Repositories.Interfaces
{
    public interface IModelPartRepository
    {
        Task<IEnumerable<ModelPart>> GetByModelIdAsync(Guid modelId);
        Task<ModelPart> GetByIdAsync(Guid id);

        Task AddAsync(ModelPart modelPart);
        Task UpdateAsync(ModelPart modelPart);

        Task SoftDeleteAsync(ModelPart modelPart);
    }
}
