using CatalogService.API.Models;

namespace CatalogService.API.Repositories.Interfaces
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllAsync();
        Task<Model?> GetByIdAsync(Guid id);
        Task<Model?> GetFullModelAsync(Guid id);
        Task AddAsync(Model model);
        Task UpdateAsync(Model model);
        Task DeleteAsync(Model model);

        Task RestoreAsync(Model model);
    }
}
