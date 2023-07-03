using BlazorAppWSAM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppWSAM.Server.Models
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly AppDbContext _context;
        public ToDoListRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }


        public async Task<ToDo> AddToDo(ToDo todo)
        {
            var result = await _context.ToDo.AddAsync(todo);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteToDo(int id)
        {
            var result = await _context.ToDo.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _context.ToDo.Remove(result);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<ToDo> GetToDoById(int id)
        {
            ToDo todo = new ToDo();
            try
            {
                todo = await _context.ToDo.Include(e => e.Status).FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception)
            {
                throw;
            }

            return todo;
        }

        public async Task<IEnumerable<ToDo>> GetToDoByStatus(Status status)
        {
            IQueryable<ToDo> query = _context.ToDo;
            if (status != null)
            {
                query = query.Where(e => e.Status == status);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ToDo>> GetToDoListAll()
        {
            return await _context.ToDo.Include(e => e.Status).ToListAsync();
        }

        public async Task<ToDo> SearchToDo(string title)
        {
            return await _context.ToDo.FirstOrDefaultAsync(e => e.Title == title);
        }

        public async Task<ToDo> UpdateToDo(ToDo todo)
        {
            var result = await _context.ToDo.FirstOrDefaultAsync(e => e.Id == todo.Id);
            if (result != null)
            {
                result.Title = todo.Title;
                result.Status = todo.Status;
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
