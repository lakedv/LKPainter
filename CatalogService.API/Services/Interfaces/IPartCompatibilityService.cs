using CatalogService.API.DTOs;

namespace CatalogService.API.Services.Interfaces
{
    public interface IPartCompatibilityService
    {
        Task<IEnumerable<PartCompatibilityResponse>> GetByModelIdAsync(Guid modelId);
        Task<PartCompatibilityResponse> CreateAsync(CreatePartCompatibilityRequest request);
        Task DeleteAsync(Guid id);
    }
}
