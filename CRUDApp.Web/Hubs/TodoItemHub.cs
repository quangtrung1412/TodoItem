using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
using BDRD.DemoCICD.CRUDAPP.Web.Application.Service;
using BDRD.DemoCICD.CRUDAPP.Web.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace BDRD.DemoCICD.CRUDAPP.Web.Hubs;
public class TodoItemHub : Hub
{
    public async Task SendUpdateStatusToAll(TodoItem todoItem)
    {
        await Clients.All.SendAsync("UpdateTodoItemStatus", todoItem);
    }
    public async Task SendUpdateNameToAll(TodoItem todoItem)
    {
        await Clients.All.SendAsync("UpdateTodoItemName",todoItem);
    }
}