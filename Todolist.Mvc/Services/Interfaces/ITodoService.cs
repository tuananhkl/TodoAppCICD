using Todolist.Mvc.Models;

namespace Todolist.Mvc.Services.Interfaces;

public interface ITodoService
{
    Task<IEnumerable<TodoDto>> GetAllTodosAsync();
    Task<TodoDto> GetTodoByIdAsync(int id);
    Task CreateTodoAsync(TodoDto todoDto);
    Task UpdateTodoAsync(int id, TodoDto todoDto);
    Task DeleteTodoAsync(int id);
}