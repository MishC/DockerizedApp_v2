using TodosApi.Models;
using TodosApi.Repository;
using TodosApi.Data;

namespace TodosApi.Service
{
    public class TodosService : ITodosService
    {

        private readonly ITodosRepository _todosRepository;

        public TodosService(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        public IQueryable<TodoItem> GetTodos()
        {

            var todos = _todosRepository.GetTodos();

            if (!todos.Any())
            {
               Console.WriteLine("No todos available to fetch.");
            }

            return todos;
        }


        public TodoItem GetTodoById(int id)
        {
            Console.WriteLine($"Fetching todo with id {id}.");

            var todo = _todosRepository.GetTodoById(id);
            if (todo == null)
            {
                Console.WriteLine($"Todo with id {id} does not exist.");
            }

            return todo;
        }


        public void AddTodo(TodoItem todo)
        {
            if (todo == null) return;

            
            _todosRepository.AddTodo(todo);
            Console.WriteLine($"Todo {todo.Title} added");
        }

        public void ToggleTodoComplete(int id)
        {
            var todo = _todosRepository.GetTodoById(id);
            if (todo == null)
            {
               Console.WriteLine($"Todo with id {id} doesn't exist.");
                return;
            }
            _todosRepository.ToggleTodoComplete(id);
           
        }


        public void UpdateTodo(int id, TodoItem newTodo)
        {
            var todo = GetTodoById(id);
            if (todo != null)
            {
                _todosRepository.UpdateTodo(newTodo);
            }
            else
            {
                Console.WriteLine($"Todo with id {id} doesn't exist.");
            }
        }


        public void DeleteTodo(int id)
        {
            var todo = _todosRepository.GetTodoById(id);
            if (todo == null)
            {
                Console.WriteLine($"Todo with id {id} doesn't exist.");

                return;
            }
            if (todo != null)
            {
                _todosRepository.DeleteTodo(id);

            }

        }

       
    }
}