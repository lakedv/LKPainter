using CatalogService.API.Models;

namespace CatalogService.API.Services.Interfaces
{
    public interface IModelService
    {
        Task<IEnumerable<Model>> GetAllAsync();
        Task<Model?> GetByIdAsync(Guid id);
        Task<Model?> GetFullModelAsync(Guid id);

        Task<Model> CreateAsync(Model model);
        Task<Model> UpdateAsync(Model model);
        Task DeleteAsync(Guid id);
        Task RestoreAsync(Guid id);
    }
}
