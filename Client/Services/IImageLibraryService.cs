using BlazorAppWSAM.Shared.Models;

namespace BlazorAppWSAM.Client.Services
{
    public interface IImageLibraryService
    {
        Task<ImageLibrary> SearchImage(string title);
        Task<IEnumerable<ImageLibrary>> GetImageByCategory(Category category);
        Task<IEnumerable<ImageLibrary>> GetImageListAll();
        Task<ImageLibrary> GetImageById(int id);
        Task<ImageLibrary> AddImage(ImageLibrary imageLibrary);
        Task UpdateImage(ImageLibrary imageLibrary);
        Task DeleteImage(ImageLibrary imageLibrary);
    }
}
