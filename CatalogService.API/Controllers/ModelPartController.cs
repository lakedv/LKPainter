using Microsoft.AspNetCore.Mvc;
using CatalogService.API.DTOs;
using CatalogService.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/model-parts")]
    public class ModelPartController : ControllerBase
    {
        private readonly IModelPartService _modelPartService;

        public ModelPartController(IModelPartService modelPartService)
        {
            _modelPartService = modelPartService;
        }

        [HttpGet("model/{modelId}")]
        public async Task<IActionResult> GetByModel(Guid modelId)
        {
            var parts = await _modelPartService.GetByModelIdAsync(modelId);

            var response = parts.Select(p => new ModelPartResponse
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                SvgPath = p.SvgPath,
                LayerOrder = p.LayerOrder,
                IsOptional = p.isOptional
            });

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateModelPartRequest request)
        {
            var part = await _modelPartService.CreateAsync(request);

            return CreatedAtAction(nameof(GetByModel),
                new { modelId = part.ModelId },
                new ModelPartResponse
                {
                    Id = part.Id,
                    Name = part.Name,
                    Type = part.Type,
                    SvgPath = part.SvgPath,
                    LayerOrder = part.LayerOrder,
                    IsOptional = part.isOptional
                });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _modelPartService.DeleteAsync(id);
            return NoContent();
        }

    }
}
