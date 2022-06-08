using BDRD.DemoCICD.CRUDAPP.Web.Application.SeedWork;

namespace BDRD.DemoCICD.CRUDAPP.Web.Application.Models;

public class TodoItemStatus : Enumeration
{
    public static TodoItemStatus NotStarted = new TodoItemStatus(0, "Not started");
    public static TodoItemStatus InProgress = new TodoItemStatus(1, "In progress");
    public static TodoItemStatus Completed = new TodoItemStatus(2, "Completed");
    public TodoItemStatus(int id, string name) : base(id, name)
    {
    }
    public static IEnumerable<TodoItemStatus> List() =>
        new[] { NotStarted, InProgress, Completed };
    
    public static TodoItemStatus FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new Exception($"Possible values for TodoItemStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static TodoItemStatus From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new Exception($"Possible values for TodoItemStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}