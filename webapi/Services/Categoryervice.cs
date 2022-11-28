namespace webapi.Services;

using Models = webapi.Models;

public class CategoryService : ICategoryService
{
    private TasksContext context;

    public CategoryService(TasksContext context)
    {
        this.context = context;
    }
    public IEnumerable<Models.Category> Get() => context.Categories;

    public async Task Save(Models.Category category)
    {
        context.Add(category);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Models.Category category)
    {
        var categoryActual = context.Categories.Find(id);

        if (categoryActual != null)
        {
            categoryActual.Name = category.Name;
            categoryActual.Description = category.Description;
            categoryActual.Weight = category.Weight;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var categoryActual = context.Categories.Find(id);

        if (categoryActual != null)
        {
            context.Remove(categoryActual);

            await context.SaveChangesAsync();
        }

    }
}

public interface ICategoryService
{
    IEnumerable<Models.Category> Get();
    Task Save(Models.Category category);
    Task Update(Guid id, Models.Category category);
    Task Delete(Guid id);
}