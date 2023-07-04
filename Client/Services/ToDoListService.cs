using BlazorAppWSAM.Shared.Models;
using System.Net.Http.Json;

namespace BlazorAppWSAM.Client.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly HttpClient _httpClient;
        public ToDoListService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._httpClient.BaseAddress = new Uri("https://blazorappwsamserver20230704093213.azurewebsites.net");
        }

        public async Task<ToDo> AddToDo(ToDo todo)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<ToDo>("api/todolist/CreateToDoList", todo);
                return await response.Content.ReadFromJsonAsync<ToDo>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteToDo(ToDo todo)
        {
            var response = await _httpClient.DeleteAsync($"api/todolist/DeleteToDoListById?id={todo.Id}");
        }

        public Task<ToDo> GetToDoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDo>> GetToDoByStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDo>> GetToDoListAll()
        {
            IEnumerable<ToDo> todo;
            todo = await _httpClient.GetFromJsonAsync<IEnumerable<ToDo>>("api/todolist/GetAllToDoList");
            return todo;
        }

        public Task<ToDo> SearchToDo(string title)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateToDo(ToDo todo)
        {
            var response = await _httpClient.PutAsJsonAsync<ToDo>($"api/todolist/UpdateToDoListById?id={todo.Id}", todo);
        }
    }
}
