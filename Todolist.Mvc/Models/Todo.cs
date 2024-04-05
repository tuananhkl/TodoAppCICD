namespace Todolist.Mvc.Models;

public class Todo : BaseEntity<int>
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}