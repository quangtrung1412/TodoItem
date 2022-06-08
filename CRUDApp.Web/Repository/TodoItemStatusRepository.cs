
using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
using BDRD.DemoCICD.CRUDAPP.Web.Application.Repository;
using BDRD.DemoCICD.CRUDAPP.Web.Database;
using Microsoft.EntityFrameworkCore;

namespace BDRD.DemoCICD.CRUDAPP.Web.Repository;
public class TodoItemStatusRepository : ITodoItemStatusRepository
{
    private AppDbContext _db;
    private ILogger<TodoItemStatusRepository> _logger;

    public TodoItemStatusRepository(AppDbContext db, ILogger<TodoItemStatusRepository> logger)
    {
        _db = db;
        _logger = logger;
    }
    public async Task<List<TodoItemStatus>> ListAsync()
    {
        List<TodoItemStatus> listStatus = new List<TodoItemStatus>();
        try
        {
            listStatus = await _db.TodoItemStatuses.ToListAsync();
            return listStatus;
        }
        catch
        {
            return listStatus;
        }


    }
}
