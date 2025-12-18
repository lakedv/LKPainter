using CatalogService.API.Models;
using CatalogService.API.Repositories.Interfaces;
using CatalogService.API.Services.Interfaces;

using CatalogService.API.Exceptions;

namespace CatalogService.API.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<Model> CreateAsync(Model model)
        {
            model.Id = Guid.NewGuid();
            model.CreatedAt = DateTime.UtcNow;

            await _modelRepository.AddAsync(model);
            return model;
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await _modelRepository.GetByIdAsync(id);
            
            if (model == null)
                throw new NotFoundException("Model Not Found");
            
            await _modelRepository.DeleteAsync(model);
        }

        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            return await _modelRepository.GetAllAsync();
        }

        public async Task<Model?> GetByIdAsync(Guid id)
        {
            return await _modelRepository.GetByIdAsync(id);
        }

        public async Task<Model?> GetFullModelAsync(Guid id)
        {
            return await _modelRepository.GetFullModelAsync(id);
        }

        public async Task<Model> UpdateAsync(Model model)
        {
            await _modelRepository.UpdateAsync(model);
            return model;
        }

        public async Task RestoreAsync(Guid id)
        {
            var model = await _modelRepository.GetByIdAsync(id);
            
            if (model == null)
                throw new NotFoundException("Model Not Found.");

            await _modelRepository.RestoreAsync(model);
        }
    }
}
