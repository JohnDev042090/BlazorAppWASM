using BlazorAppWSAM.Shared.Models;

namespace BlazorAppWSAM.Server.Models
{
    public interface IToDoListRepository
    {
        Task<ToDo> SearchToDo(string title);
        Task<IEnumerable<ToDo>> GetToDoByStatus(Status status);
        Task<IEnumerable<ToDo>> GetToDoListAll();
        Task<ToDo> GetToDoById(int id);
        Task<ToDo> AddToDo(ToDo todo);
        Task<ToDo> UpdateToDo(ToDo todo);
        Task DeleteToDo(int id);
    }
}
