using AutoMapper;
using Todolist.Mvc.Models;
using Todolist.Mvc.Repositories.Interfaces;
using Todolist.Mvc.Services.Interfaces;

namespace Todolist.Mvc.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public TodoService(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TodoDto>> GetAllTodosAsync()
    {
        var todos = await _todoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TodoDto>>(todos);
    }

    public async Task<TodoDto> GetTodoByIdAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        return _mapper.Map<TodoDto>(todo);
    }

    public async Task CreateTodoAsync(TodoDto todoDto)
    {
        var todo = _mapper.Map<Todo>(todoDto);
        todo.CreatedAt = DateTime.UtcNow;
        await _todoRepository.AddAsync(todo);
    }

    public async Task UpdateTodoAsync(int id, TodoDto todoDto)
    {
        var existingTodo = await _todoRepository.GetByIdAsync(id);
        if (existingTodo == null)
            throw new Exception("Todo not found");

        var updatedTodo = _mapper.Map(todoDto, existingTodo);
        updatedTodo.ModifiedAt = DateTime.UtcNow;

        await _todoRepository.UpdateAsync(updatedTodo);
    }

    public async Task DeleteTodoAsync(int id)
    {
        await _todoRepository.DeleteAsync(id);
    }
}