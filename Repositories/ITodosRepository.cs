using TodosApi.Models;

namespace TodosApi.Repository
{
    public interface ITodosRepository
    {
        IQueryable<TodoItem> GetTodos();
        TodoItem GetTodoById(int id);
        void AddTodo(TodoItem todo);
        void UpdateTodo(TodoItem newTodo);
        void DeleteTodo(int id);
        void ToggleTodoComplete(int id);

    }
}