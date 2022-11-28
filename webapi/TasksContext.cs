namespace webapi;

using Microsoft.EntityFrameworkCore;
using webapi.Models;

public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(
            new Category()
            {
                CategoryId = Guid.Parse("a847fe4b-f504-4ce6-88b4-5a0e7d04259e"),
                Name = "pending activities",
                Weight = 20
            });
        categoriesInit.Add(
            new Category()
            {
                CategoryId = Guid.Parse("8ef5d82a-1c69-4039-85d9-0ca6a1afa093"),
                Name = "Personal activities",
                Weight = 50
            });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(c => c.CategoryId);
            category.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);
            category.Property(c => c.Description).IsRequired(false);
            category.Property(c => c.Weight);
            category.HasData(categoriesInit);
        });

        List<Task> tasksInit = new List<Task>()
        {
            new Task()
            {
                TaskId = Guid.Parse("4f97edb4-a1bb-4122-adbf-0393f2194e63"),
                CategoryId =  Guid.Parse("a847fe4b-f504-4ce6-88b4-5a0e7d04259e"),
                PriorityTask = Priority.Middle,
                Title = "Pay public services",
                CreationDate = DateTime.Now
            },
            new Task()
            {
                TaskId = Guid.Parse("14af8dea-0be2-4bde-b673-ae6563db4823"),
                CategoryId =  Guid.Parse("8ef5d82a-1c69-4039-85d9-0ca6a1afa093"),
                PriorityTask = Priority.Low,
                Title = "Finish watching movies on Netflix",
                CreationDate = DateTime.Now
            }
        };
        modelBuilder.Entity<Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(t => t.TaskId);
            task.HasOne(t => t.Category)
                .WithMany(c => c.Task)
                .HasForeignKey(t => t.CategoryId);
            task.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);
            task.Property(t => t.Description).IsRequired(false);
            task.Property(t => t.PriorityTask);
            task.Property(t => t.CreationDate);
            task.Ignore(t => t.Summary);
            task.HasData(tasksInit);
        });
    }
}
