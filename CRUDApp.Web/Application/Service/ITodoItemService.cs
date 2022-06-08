using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;

namespace BDRD.DemoCICD.CRUDAPP.Web.Application.Service;

public interface ITodoItemService
{
    Task<List<TodoItem>> ListAsync();
    Task<TodoItem> GetByIdAsync(int todoItemId);
    Task<TodoItem> AddAsync(TodoItem todoItem);
    Task<TodoItem> UpdateAsync(TodoItem todoItem);
    Task<TodoItem> DeleteAsync(int todoItemId);
}