using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;

namespace BDRD.DemoCICD.CRUDAPP.Web.Database;

public class AppDbContextSeed
{
    public async Task SeedAsync(AppDbContext context, ILogger<AppDbContextSeed> logger)
    {
        if (!context.TodoItemStatuses.Any())
        {
            logger.LogInformation("Generate default data for todo item status table");
            context.TodoItemStatuses.AddRange(GetPredefinedTodoItemStatus());
            await context.SaveChangesAsync();
        }
        if (!context.TodoItems.Any())
        {
            logger.LogInformation("Generate default data for todo item table");
            context.TodoItems.AddRange(GetPredefinedTodoItem());
            await context.SaveChangesAsync();
        }
    }

    private IEnumerable<TodoItemStatus> GetPredefinedTodoItemStatus()
    {
        return new List<TodoItemStatus>()
        {
            TodoItemStatus.NotStarted,
            TodoItemStatus.InProgress,
            TodoItemStatus.Completed
        };
    }

    private IEnumerable<TodoItem> GetPredefinedTodoItem()
    {
        return new List<TodoItem>()
        {
            new TodoItem {Name = "Todo item 1", StartDate = DateTime.Now.AddDays(-2), DueDate = DateTime.Now,
            Note = "Todo item 1 note", Status = TodoItemStatus.Completed},
            new TodoItem {Name = "Todo item 2", StartDate = DateTime.Now.AddDays(-1), DueDate = DateTime.Now.AddDays(2),
            Note = "Todo item 2 note", Status = TodoItemStatus.InProgress},
            new TodoItem {Name = "Todo item 3", StartDate = DateTime.Now, DueDate = DateTime.Now.AddDays(2),
            Note = "Todo item 3 note", Status = TodoItemStatus.NotStarted}
        };
    }
}