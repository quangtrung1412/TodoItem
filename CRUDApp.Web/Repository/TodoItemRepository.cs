using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
using BDRD.DemoCICD.CRUDAPP.Web.Application.Repository;
using BDRD.DemoCICD.CRUDAPP.Web.Database;
using Microsoft.EntityFrameworkCore;

namespace BDRD.DemoCICD.CRUDAPP.Web.Repository;

#nullable disable
public class TodoItemRepository : ITodoItemRepository
{
    private readonly AppDbContext _db;
    private readonly ILogger<TodoItemRepository> _logger;

    public TodoItemRepository(AppDbContext db, ILogger<TodoItemRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<TodoItem> AddAsync(TodoItem todoItem)
    {

        try
        {
            if (todoItem != null)
            {
                _db.Add(todoItem);
                await _db.SaveChangesAsync();
            }
            return todoItem;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }

    }

    public async Task<TodoItem> DeleteAsync(int id)
    {
        TodoItem todoItem = new TodoItem();
        try
        {
            todoItem = await _db.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                _db.TodoItems.Remove(todoItem);
                await _db.SaveChangesAsync();
            }
            return todoItem;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }

    public async Task<TodoItem> GetByIdAsync(int todoItemId)
    {
        try
        {
            var todoItem = await _db.TodoItems.FirstOrDefaultAsync(m => m.Id.Equals(todoItemId));
            return todoItem;
        }
        catch
        {
            return null;
        }

    }

    public async Task<List<TodoItem>> ListAsync()
    {
        List<TodoItem> data = new List<TodoItem>();
        try
        {
            data = await _db.TodoItems.ToListAsync();
            return data;
        }
        catch
        {
            return data;
        }

    }



    public async Task<TodoItem> UpdateAsync(TodoItem todoItem)
    {
        try
        {
            if (todoItem != null)
            {
                _db.TodoItems.Update(todoItem);
                await _db.SaveChangesAsync();

            }
            return todoItem;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }



}