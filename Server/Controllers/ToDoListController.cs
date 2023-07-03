using BlazorAppWSAM.Server.Models;
using BlazorAppWSAM.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWSAM.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;
        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            this._toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllToDoList()
        {
            try
            {
                return Ok(await _toDoListRepository.GetToDoListAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed retrieving data from DB");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ToDo>> GetToDoListById(int id)
        {
            try
            {
                var result = await _toDoListRepository.GetToDoById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed retrieving data from DB");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> CreateToDoList(ToDo todo)
        {
            try
            {
                if (todo == null) return BadRequest();

                var createToDo = await _toDoListRepository.AddToDo(todo);
                return CreatedAtAction(nameof(GetToDoListById), new { id = createToDo.Id }, createToDo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed creating record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ToDo>> UpdateToDoListById(int id, ToDo todo)
        {
            try
            {
                if (id == todo.Id) return BadRequest();
                var todoUpdate = await _toDoListRepository.GetToDoById(id);
                if (todoUpdate == null)
                {
                    return NotFound($"To do item not found");
                }

                return await _toDoListRepository.UpdateToDo(todo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed updating record");
            }
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult> DeleteToDoListById(int id)
        {
            try
            {
                var todoDelete = await _toDoListRepository.GetToDoById(id);
                if (todoDelete == null)
                {
                    return NotFound($"To do item not found");
                }

                await _toDoListRepository.DeleteToDo(id);

                return Ok("Successfully deleted record");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed deleting record");
            }
        }


    }
}
