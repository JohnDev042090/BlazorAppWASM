using BlazorAppWSAM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppWSAM.Server.Models
{
    public class ImageLibraryRepository : IImageLibraryRepository
    {
        private readonly AppDbContext _context;
        public ImageLibraryRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<ImageLibrary> AddImage(ImageLibrary imageLibrary)
        {
            var result = await _context.ImageLibrary.AddAsync(imageLibrary);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteImage(int id)
        {
            var result = await _context.ImageLibrary.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _context.ImageLibrary.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ImageLibrary>> GetImageByCategory(Category category)
        {
            IQueryable<ImageLibrary> query = _context.ImageLibrary;
            if (category != null)
            {
                query = query.Where(e => e.Category == category);
            }
            return await query.ToListAsync();
        }

        public async Task<ImageLibrary> GetImageById(int id)
        {
            ImageLibrary imageLibrary = new ImageLibrary();
            try
            {
                imageLibrary = await _context.ImageLibrary.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception)
            {
                throw;
            }

            return imageLibrary;
        }

        public async Task<IEnumerable<ImageLibrary>> GetImageListAll()
        {
            return await _context.ImageLibrary.Include(e => e.Category).ToListAsync();
        }

        public Task<IEnumerable<ImageLibrary>> SearchImage(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<ImageLibrary> UpdateImage(ImageLibrary imageLibrary)
        {
            var result = await _context.ImageLibrary.FirstOrDefaultAsync(e => e.Id == imageLibrary.Id);
            if (result != null)
            {
                result.Title = imageLibrary.Title;
                result.Category = imageLibrary.Category;
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
