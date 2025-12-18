using CatalogService.API.Models;

namespace CatalogService.API.Repositories.Interfaces
{
    public interface IPartCompatibilityRepository
    {
        Task<IEnumerable<PartCompatibility>> GetByModelIdAsync(Guid modelId);
        Task AddAsync (PartCompatibility partCompatibility);
        Task DeleteAsync(PartCompatibility partCompatibility);
        Task<PartCompatibility> GetByIdAsync(Guid id);
    }
}
