using Microsoft.EntityFrameworkCore;
using Todolist.Mvc.Models;

namespace Todolist.Mvc.Data;

public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<Todo>().HasData(
            new Todo { Id = 1, Title = "Task 1", IsCompleted = false, DueDate = DateTime.Now.AddDays(1) },
            new Todo { Id = 2, Title = "Task 2", IsCompleted = false, DueDate = DateTime.Now.AddDays(2) },
            new Todo { Id = 3, Title = "Task 3", IsCompleted = false, DueDate = DateTime.Now.AddDays(3) }
        );
    }
}