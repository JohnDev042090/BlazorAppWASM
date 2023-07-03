using BlazorAppWSAM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppWSAM.Server.Models
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;
        public StatusRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<IEnumerable<Status>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task<Status> GetStatusById(int id)
        {
            return await _context.Status.FirstOrDefaultAsync(e => e.StatusId == id);
        }
    }
}
