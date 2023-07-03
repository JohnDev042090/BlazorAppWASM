using BlazorAppWSAM.Shared.Models;

namespace BlazorAppWSAM.Server.Models
{
    public interface IImageLibraryRepository
    {
        Task<IEnumerable<ImageLibrary>> SearchImage(string title);
        Task<IEnumerable<ImageLibrary>> GetImageByCategory(Category category);
        Task<IEnumerable<ImageLibrary>> GetImageListAll();
        Task<ImageLibrary> GetImageById(int id);
        Task<ImageLibrary> AddImage(ImageLibrary todo);
        Task<ImageLibrary> UpdateImage(ImageLibrary todo);
        Task DeleteImage(int id);
    }
}
