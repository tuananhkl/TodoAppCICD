using Microsoft.EntityFrameworkCore;
using Todolist.Mvc.Models;

namespace Todolist.Mvc.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            // Check if there are any existing todos
            if (context.Todos.Any())
            {
                return;   // Database has been seeded
            }

            // Seed initial todos
            context.Todos.AddRange(
                new Todo
                {
                    Title = "Task 1",
                    IsCompleted = false,
                    DueDate = DateTime.Now.AddDays(1)
                },
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