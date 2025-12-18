using CatalogService.API.DTOs;
using CatalogService.API.Exceptions;
using CatalogService.API.Models;
using CatalogService.API.Repositories.Interfaces;
using CatalogService.API.Services.Interfaces;

namespace CatalogService.API.Services
{
    public class PartCompatibilityService : IPartCompatibilityService
    {
        private readonly IPartCompatibilityRepository _partCompatibilityRepository;
        private readonly IModelPartRepository _modelPartRepository;

        public PartCompatibilityService
            (IPartCompatibilityRepository partCompatibilityRepository, 
            IModelPartRepository modelPartRepository)
        {
            _partCompatibilityRepository = partCompatibilityRepository;
            _modelPartRepository = modelPartRepository;
        }

        public async Task<PartCompatibilityResponse> CreateAsync(CreatePartCompatibilityRequest request)
        {
            if (request.SourcePartId == request.CompatibleWithPartId)
                throw new DomainException("A part cannot be compatible with itself.");

            var sourcePart = await _modelPartRepository.GetByIdAsync(request.SourcePartId);
            var compatiblePart = await _modelPartRepository.GetByIdAsync(request.CompatibleWithPartId);

            if (sourcePart == null || compatiblePart == null)
                throw new NotFoundException("One or Both parts do not exist.");

            if (sourcePart.ModelId != compatiblePart.ModelId)
                throw new DomainException("Parts must belong to the same model.");

            var compatibility = new PartCompatibility
            {
                Id = Guid.NewGuid(),
                SourcePartId = request.SourcePartId,
                CompatibleWithPartId = request.CompatibleWithPartId
            };

            await _partCompatibilityRepository.AddAsync(compatibility);

            var loaded = await _partCompatibilityRepository.GetByIdAsync(compatibility.Id)!;

            return new PartCompatibilityResponse
            {
                Id = loaded.Id,
                SourcePartId = loaded.SourcePartId,
                SourcePartName = loaded.SourcePart.Name,
                CompatibleWithPartId = loaded.CompatibleWithPartId,
                CompatibleWithPartName = loaded.CompatibleWithPart.Name
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var compatibility = await _partCompatibilityRepository.GetByIdAsync(id);
            if (compatibility == null)
                throw new Exception("Compatibility not Found");

            await _partCompatibilityRepository.DeleteAsync(compatibility);
        }

        public async Task<IEnumerable<PartCompatibilityResponse>> GetByModelIdAsync(Guid modelId)
        {
            var items = await _partCompatibilityRepository.GetByModelIdAsync(modelId);

            return items.Select(pc => new PartCompatibilityResponse
            {
                Id = pc.Id,
                SourcePartId= pc.SourcePartId,
                SourcePartName= pc.SourcePart.Name,
                CompatibleWithPartId= pc.CompatibleWithPartId,
                CompatibleWithPartName= pc.CompatibleWithPart.Name
            });
        }
    }
}
