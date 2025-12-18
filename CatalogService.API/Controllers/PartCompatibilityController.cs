using Microsoft.AspNetCore.Mvc;
using CatalogService.API.DTOs;
using CatalogService.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/part-compatibilities")]
    public class PartCompatibilityController : ControllerBase
    {
        private readonly IPartCompatibilityService _service;

        public PartCompatibilityController(IPartCompatibilityService service)
        {
            _service = service;
        }

        [HttpGet("model/{modelId}")]
        public async Task<IActionResult> GetByModel(Guid modelId)
        {
            return Ok(await _service.GetByModelIdAsync(modelId));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePartCompatibilityRequest request)
        {
            return Ok(await _service.CreateAsync(request));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
