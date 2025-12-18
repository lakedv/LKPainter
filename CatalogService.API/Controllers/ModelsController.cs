using CatalogService.API.DTOs;
using CatalogService.API.Models;
using CatalogService.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/models")]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _modelService.GetAllAsync();

            var response = models.Select(m => new ModelResponse
            {
                Id = m.Id,
                Name = m.Name,
                Faction = m.Faction,
                BaseSvgPath = m.BaseSvgPath,
                IsBaseConcept = m.IsBaseConcept,
                CreatedAt = m.CreatedAt,
            });

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _modelService.GetByIdAsync(id);
            if (model == null)
                return NotFound();
            return Ok(model);
        }

        [HttpGet("{id:guid}/full")]
        public async Task<IActionResult> GetFull(Guid id)
        {
            var model = await _modelService.GetFullModelAsync(id);
            if (model == null)
                return NotFound();
            return Ok(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ModelCreateRequest request)
        {
            var model = new Model
            {
                Name = request.Name,
                Faction = request.Faction,
                BaseSvgPath = request.BaseSvgPath,
                IsBaseConcept = request.IsBaseConcept,
            };

            var created = await _modelService.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ModelUpdateRequest request)
        {
            var model = await _modelService.GetByIdAsync(id);
            if (model == null)
                return NotFound();

            model.Name = request.Name;
            model.Faction = request.Faction;
            model.BaseSvgPath = request.BaseSvgPath;

            await _modelService.UpdateAsync(model);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _modelService.DeleteAsync(id);
            return Ok(new { message = "Model Deleted." });
        }

        [HttpPost("{id:guid}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            await _modelService.RestoreAsync(id);
            return Ok(new { message = "Model Restored" });
        }
    }
}
