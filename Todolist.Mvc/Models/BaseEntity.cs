namespace Todolist.Mvc.Models;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}