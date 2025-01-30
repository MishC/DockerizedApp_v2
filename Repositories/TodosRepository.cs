using TodosApi.Data;
using TodosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodosApi.Repository
{
	public class TodosRepository : ITodosRepository
	{
		private readonly AppDbContext _context;

		public TodosRepository(AppDbContext context)
		{
			_context = context;
		}


		public IQueryable<TodoItem> GetTodos() => _context.Todos;

		public TodoItem GetTodoById(int id) => _context.Todos
			.FirstOrDefault(b => b.Id == id);

		public void AddTodo(TodoItem todo)
		{
			_context.Todos.Add(todo);
			_context.SaveChanges();
		}

		public void UpdateTodo(TodoItem newtodo)
		{
			
				_context.Todos.Update(newtodo);
				_context.SaveChanges();
		
			
		}

		public void ToggleTodoComplete(int id)
		{
			var todo = GetTodoById(id);
			if (todo != null)
			{
				todo.IsComplete = !todo.IsComplete;
				
				_context.SaveChanges();
			}
		}

		public void DeleteTodo(int id)
		{
			var todo = GetTodoById(id);
			if (todo != null)
			{
				_context.Todos.Remove(todo);
				_context.SaveChanges();
			}
		}


	}
}