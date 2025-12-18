using CatalogService.API.Data;
using CatalogService.API.Models;
using CatalogService.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.API.Repositories
{
    public class PartCompatibilityRepository : IPartCompatibilityRepository
    {
        private readonly CatalogDbContext _context;

        public PartCompatibilityRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PartCompatibility partCompatibility)
        {
            _context.partCompatibilities.Add(partCompatibility);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PartCompatibility partCompatibility)
        {
            _context.partCompatibilities.Remove(partCompatibility);
            await _context.SaveChangesAsync();
        }

        public async Task<PartCompatibility> GetByIdAsync(Guid id)
        {
            return await _context.partCompatibilities
                .Include(pc => pc.SourcePart)
                .Include(pc => pc.CompatibleWithPart)
                .FirstOrDefaultAsync(pc => pc.Id == id);
        }

        public async Task<IEnumerable<PartCompatibility>> GetByModelIdAsync(Guid modelId)
        {
            return await _context.partCompatibilities
                .Include(pc => pc.SourcePart)
                .Include(pc => pc.CompatibleWithPart)
                .Where(pc => pc.SourcePart.ModelId == modelId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
