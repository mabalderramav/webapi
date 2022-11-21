namespace webapi.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("Task")]
public class Task
{
    public Guid TaskId { get; set; }

    public Guid CategoryId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority PriorityTask { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Category Category { get; set; }

    public string Summary { get; set; }
}

public enum Priority
{
    Low,
    Middle,
    High
}
