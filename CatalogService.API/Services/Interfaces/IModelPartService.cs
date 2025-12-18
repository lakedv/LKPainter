using CatalogService.API.DTOs;
using CatalogService.API.Models;

namespace CatalogService.API.Services.Interfaces
{
    public interface IModelPartService
    {
        Task<IEnumerable<ModelPart>> GetByModelIdAsync(Guid modelId);
        Task<ModelPart> CreateAsync(CreateModelPartRequest request);
        Task DeleteAsync(Guid id);
    }
}
