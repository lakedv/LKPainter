using CatalogService.API.Data;
using CatalogService.API.Models;
using CatalogService.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.API.Repositories
{
    public class ModelPartRepository : IModelPartRepository
    {
        private readonly CatalogDbContext _context;

        public ModelPartRepository(CatalogDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ModelPart modelPart)
        {
            _context.ModelParts.Add(modelPart);
            await _context.SaveChangesAsync();
        }

        public async Task<ModelPart> GetByIdAsync(Guid id)
        {
            return await _context.ModelParts
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public async Task<IEnumerable<ModelPart>> GetByModelIdAsync(Guid modelId)
        {
            return await _context.ModelParts
                .Where(p => p.ModelId == modelId && !p.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task SoftDeleteAsync(ModelPart modelPart)
        {
            modelPart.IsDeleted = true;
            modelPart.DeletedAt = DateTime.UtcNow;

            _context.ModelParts.Update(modelPart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ModelPart modelPart)
        {
            _context.ModelParts.Update(modelPart);
            await _context.SaveChangesAsync();
        }
    }
}
