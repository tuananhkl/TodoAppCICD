namespace Todolist.Mvc.Models;

public class TodoDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}