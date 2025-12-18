using CatalogService.API.Data;
using CatalogService.API.Models;
using CatalogService.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.API.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly CatalogDbContext _context;
        public ModelRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Model model)
        {
            _context.Models.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Model model)
        {
            model.IsDeleted = true;
            model.DeletedAt = DateTime.UtcNow;

            _context.Models.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            return await _context.Models
                .Where(m => !m.IsDeleted)
                .Include(m => m.Parts)
                .Include(m => m.PartCompatibilities)
                .Include(m => m.DefaultLayerGroups)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Model?> GetByIdAsync(Guid id)
        {
            return await _context.Models
                .Include(m => m.Parts)
                .Include(m => m.PartCompatibilities)
                .Include(m => m.DefaultLayerGroups)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
        }

        public async Task<Model?> GetFullModelAsync(Guid id)
        {
            return await _context.Models
                .Include(m => m.Parts)
                .Include(m => m.PartCompatibilities)
                .ThenInclude(pc => pc.SourcePart)
                .Include(m => m.PartCompatibilities)
                .ThenInclude(pc => pc.CompatibleWithPart)
                .Include(m => m.DefaultLayerGroups)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
        }

        public async Task UpdateAsync(Model model)
        {
            _context.Models.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task RestoreAsync(Model model)
        {
            model.IsDeleted = false;
            model.DeletedAt = null;

            _context.Models.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
