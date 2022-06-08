using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
using BDRD.DemoCICD.CRUDAPP.Web.Application.Repository;
using BDRD.DemoCICD.CRUDAPP.Web.Application.Service;

namespace BDRD.DemoCICD.CRUDAPP.Web.Application;

#nullable disable
public class TodoItemService : ITodoItemService
{
    private const int MinimumNameLength = 3;
    private const int Date1SameDate2Int = 0;
    private readonly ITodoItemRepository _repository;
    private readonly ILogger<TodoItemService> _logger;

    public TodoItemService(ITodoItemRepository repository, ILogger<TodoItemService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<TodoItem> AddAsync(TodoItem todoItem)
    {
        if (IsValidName(todoItem.Name) && IsValidStartDateAndDueDate(todoItem.StartDate, todoItem.DueDate))
        {
            return await _repository.AddAsync(todoItem);
        }
        return null;
    }

    public async Task<TodoItem> DeleteAsync(int todoItemId)
    {
        return await _repository.DeleteAsync(todoItemId);
    }

    public async Task<TodoItem> GetByIdAsync(int todoItemId)
    {
        return await _repository.GetByIdAsync(todoItemId);
    }

    public async Task<List<TodoItem>> ListAsync()
    {
        return await _repository.ListAsync();
    }
    public async Task<TodoItem> UpdateAsync(TodoItem todoItem)
    {
        if (IsValidName(todoItem.Name) && IsValidStartDateAndDueDate(todoItem.StartDate, todoItem.DueDate))
        {
            return await _repository.UpdateAsync(todoItem);
        }
        return null;
    }

    private bool IsValidName(string name)
    {
        return name != null && name.Trim().Length >= MinimumNameLength;
    }

    private bool IsValidStartDateAndDueDate(DateTime startDate, DateTime dueDate)
    {
        return dueDate.Date.CompareTo(startDate.Date) >= Date1SameDate2Int;
    }
}