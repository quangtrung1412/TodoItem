using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;

namespace BDRD.DemoCICD.CRUDAPP.Web.Application.Service;
public interface ITodoItemStatusService
{
    Task<List<TodoItemStatus>> ListAsync();
}