using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
using BDRD.DemoCICD.CRUDAPP.Web.Application.Service;
using BDRD.DemoCICD.CRUDAPP.Web.DTOs;
using BDRD.DemoCICD.CRUDAPP.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BDRD.DemoCICD.CRUDAPP.Web.ApiControllers;
[ApiController]
[Route("/api/todoItem")]
public class TodoItemApiController : ControllerBase
{
    private ITodoItemService _service;
    private ILogger<TodoItemApiController> _logger;

    public TodoItemApiController(ITodoItemService service, ILogger<TodoItemApiController> logger)
    {
        _service = service;
        _logger = logger;
    }
    [HttpPut("update-status/{todoItemId}")]
    public async Task<IActionResult> UpdateTodoItem(int todoItemId, TodoItemUpdateStatusDTO todoItemUpdateStatusDTO)

    {
        if (todoItemUpdateStatusDTO.TodoItemId == todoItemId)
        {
            var todoItemDetail = await _service.GetByIdAsync(todoItemUpdateStatusDTO.TodoItemId);
            if (todoItemDetail != null)
            {
                switch (todoItemUpdateStatusDTO.StatusId)
                {
                    case 0:
                        todoItemDetail.Status = TodoItemStatus.From(todoItemUpdateStatusDTO.StatusId + 1);
                        break;
                    case 1:
                        todoItemDetail.Status = TodoItemStatus.From(todoItemUpdateStatusDTO.StatusId + 1);
                        break;
                    default:
                        todoItemDetail.Status = TodoItemStatus.From(0);
                        break;
                }
                return Ok(await _service.UpdateAsync(todoItemDetail));

            }
        }
        return BadRequest();
    }
    [HttpPut("update-name/{todoItemId}")]
    public async Task<IActionResult> UpdateTodoItemName(int todoItemId, TodoItemUpdateNameDTO todoItemUpdateNameDTO)
    {
        if(todoItemUpdateNameDTO.TodoItemId==todoItemId)
        {
              var todoItemDetail = await _service.GetByIdAsync(todoItemUpdateNameDTO.TodoItemId);
              if (todoItemDetail != null)
              {
                  todoItemDetail.Name = todoItemUpdateNameDTO.TodoItemName;
                  
               return Ok(await _service.UpdateAsync(todoItemDetail));
              }
        }
        return BadRequest();
    }
}