namespace BDRD.DemoCICD.CRUDAPP.Web.Application.Models;

#nullable disable
public class TodoItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TodoItemStatus Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Note { get; set; }
}