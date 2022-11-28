namespace webapi.Services;

using Models = webapi.Models;

public class TaskService : ITaskService
{
    private TasksContext context;

    public TaskService(TasksContext context)
    {
        this.context = context;
    }

    public IEnumerable<Models.Task> Get() => context.Tasks;

    public async Task Save(Models.Task task)
    {
        context.Add(task);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Models.Task task)
    {
        var taskActual = context.Tasks.Find(id);

        if (taskActual != null)
        {
            taskActual.Title = task.Title;
            taskActual.Summary = task.Summary;
            taskActual.Description = task.Description;
            taskActual.PriorityTask = task.PriorityTask;
            taskActual.CategoryId = task.CategoryId;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var taskActual = context.Tasks.Find(id);

        if (taskActual != null)
        {
            context.Remove(taskActual);

            await context.SaveChangesAsync();
        }
    }
}

public interface ITaskService
{
    IEnumerable<Models.Task> Get();
    Task Update(Guid id, Models.Task category);
    Task Save(Models.Task task);
    Task Delete(Guid id);
}