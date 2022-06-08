using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;

using BDRD.DemoCICD.CRUDAPP.Web.Application.Repository;

namespace BDRD.DemoCICD.CRUDAPP.Web.Application.Service;

public class TodoItemStatusService : ITodoItemStatusService
{
    private ITodoItemStatusRepository _repository;
    private ILogger _logger;

    public TodoItemStatusService(ITodoItemStatusRepository repository, ILogger<TodoItemStatusService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<List<TodoItemStatus>> ListAsync()
    {
        return await _repository.ListAsync();
    }
}
