using BlazorAppWSAM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppWSAM.Server.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Category.FirstOrDefaultAsync(e => e.CategoryId == id);
        }
    }
}
