using Microsoft.AspNetCore.Mvc;
using TodosApi.Models;
using TodosApi.Data;
using TodosApi.Service;


namespace TodosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TodosController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly ITodosService _todosService;



        public TodosController(AppDbContext context, ITodosService todosService)
        {
            _context = context;
            _todosService = todosService;
        }


        // GET: api/todos
        [HttpGet]
        public IActionResult GetTodos()
        {

            var todos = _todosService.GetTodos();
            return Ok(todos);

        }


        // GET: api/todos/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todosService.GetTodoById(id);

            return Ok(todo);
        }


        //POST: api/todos/

        [HttpPost]
        public IActionResult Create(TodoItem todo)
        {

            _todosService.AddTodo(todo);

            return NoContent();

        }


        // PUT: api/todos/{id}
        [HttpPut("{id}")]

        public IActionResult Update(int id, TodoItem newTodo)
        {
            _todosService.UpdateTodo(id, newTodo);
            return NoContent();
        }

        // PUT: api/todos/toggle/{id}
        [HttpPut("toggle/{id}")]
        public IActionResult ToggleTodoComplete(int id)
        {
            _todosService.ToggleTodoComplete(id);
            return Ok(new { message = "Todo completion status toggled successfully." });

        }

        //DELETE: api/todos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _todosService.DeleteTodo(id);
            return NoContent();
        }

    }
}