using BlazorAppWSAM.Shared.Models;

namespace BlazorAppWSAM.Server.Models
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<Category> GetCategoryById(int id);
    }
}
