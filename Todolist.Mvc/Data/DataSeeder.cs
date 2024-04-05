using Microsoft.EntityFrameworkCore;
using Todolist.Mvc.Models;

namespace Todolist.Mvc.Data;

public class DataSeeder
{
    private readonly IServiceProvider _serviceProvider;

    public DataSeeder(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void SeedData()
    {
        using (var context = new AppDbContext(
                   _serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            // Check if there are any existing todos
            if (context.Todos.Any())
            {
                return;   // Database has been seeded
            }

            // Seed initial todos
            var todo = new Todo
                {
                    Title = "Task 1",
                    IsCompleted = false
                };
            todo.DueDate = DateTime.Now.AddDays(1);
            context.Todos.AddRange(
                todo,
                new Todo
                {
                    Title = "Task 2",
                    IsCompleted = false,
                    DueDate = DateTime.Now.AddDays(2)
                },
                new Todo
                {
                    Title = "Task 3",
                    IsCompleted = false,
                    DueDate = DateTime.Now.AddDays(3)
                }
            );
            context.SaveChanges();
        }
    }
}