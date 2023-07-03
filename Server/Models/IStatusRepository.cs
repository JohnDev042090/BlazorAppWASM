using BlazorAppWSAM.Shared.Models;

namespace BlazorAppWSAM.Server.Models
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetStatus();
        Task<Status> GetStatusById(int id);
    }
}
