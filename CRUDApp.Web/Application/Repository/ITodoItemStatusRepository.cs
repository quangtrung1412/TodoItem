
using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
namespace BDRD.DemoCICD.CRUDAPP.Web.Application.Repository;
public interface ITodoItemStatusRepository
{
    Task<List<TodoItemStatus>> ListAsync();
}