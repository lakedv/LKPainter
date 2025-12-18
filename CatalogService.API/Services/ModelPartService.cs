using CatalogService.API.DTOs;
using CatalogService.API.Exceptions;
using CatalogService.API.Models;
using CatalogService.API.Repositories.Interfaces;
using CatalogService.API.Services.Interfaces;

namespace CatalogService.API.Services
{
    public class ModelPartService : IModelPartService
    {
        private readonly IModelPartRepository _modelPartRepository;
        private readonly IModelRepository _modelRepository;

        public ModelPartService
            (IModelPartRepository modelPartRepository, 
            IModelRepository modelRepository)
        {
            _modelPartRepository = modelPartRepository;
            _modelRepository = modelRepository;
        }

        public async Task<ModelPart> CreateAsync(CreateModelPartRequest request)
        {
            var model = await _modelRepository.GetByIdAsync(request.ModelId);
            if (model == null)
                throw new NotFoundException("Model Not Found.");

            var part = new ModelPart
            {
                Id = Guid.NewGuid(),
                ModelId = request.ModelId,
                Name = request.Name,
                Type = request.Type,
                SvgPath = request.SvgPath,
                LayerOrder = request.LayerOrder,
                isOptional = request.IsOptional
            };

            await _modelPartRepository.AddAsync(part);
            return part;

        }
        public async Task DeleteAsync(Guid id)
        {
            var part = await _modelPartRepository.GetByIdAsync(id);
            if (part == null)
                throw new NotFoundException("ModelPart not Found");
        }

        public async Task<IEnumerable<ModelPart>> GetByModelIdAsync(Guid modelId)
        {
            return await _modelPartRepository.GetByModelIdAsync(modelId);
        }
    }
}
