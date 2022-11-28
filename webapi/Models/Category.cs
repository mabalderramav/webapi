namespace webapi.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Category")]
public class Category
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Weight { get; set; }

    [JsonIgnore]
    public virtual ICollection<Task> Task { get; set; }
}
