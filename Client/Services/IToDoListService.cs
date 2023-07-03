using BlazorAppWSAM.Shared.Models;

namespace BlazorAppWSAM.Client.Services
{
    public interface IToDoListService
    {
        Task<ToDo> SearchToDo(string title);
        Task<IEnumerable<ToDo>> GetToDoByStatus(Status status);
        Task<IEnumerable<ToDo>> GetToDoListAll();
        Task<ToDo> GetToDoById(int id);
        Task<ToDo> AddToDo(ToDo todo);
        Task UpdateToDo(ToDo todo);
        Task DeleteToDo(ToDo todo);
    }
}
