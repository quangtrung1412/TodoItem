using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
using BDRD.DemoCICD.CRUDAPP.Web.Application.Service;
using BDRD.DemoCICD.CRUDAPP.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BDRD.DemoCICD.CRUDAPP.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITodoItemService _service;
    private readonly ITodoItemStatusService _statusService;

    public HomeController(ITodoItemService service, ITodoItemStatusService statusService, ILogger<HomeController> logger)
    {
        _logger = logger;
        _service = service;
        _statusService = statusService;
    }
    public async Task<IActionResult> Index()
    {
        var data = await _service.ListAsync();
        List<DisplayViewModel> listDataView = new List<DisplayViewModel>();
        foreach (var item in data)
        {
            DisplayViewModel dataView = new DisplayViewModel();
            ItemStatusViewModel itemStatusViewModel = new ItemStatusViewModel();
            dataView.Id = item.Id;
            dataView.Name = item.Name;
            itemStatusViewModel.Id = item.Status.Id;
            itemStatusViewModel.Name = item.Status.Name;
            dataView.Status = itemStatusViewModel;
            dataView.StartDate = item.StartDate.ToString("dd-MM-yyyy");
            dataView.DueDate = item.DueDate.ToString("dd-MM-yyyy");
            dataView.Note = item.Note;
            listDataView.Add(dataView);
        }

        return View(listDataView);
    }
    public IActionResult TodoItemInsertPage()
    {
        return View();
    }
    public async Task<IActionResult> InsertTodoItem(UpsertViewModel upsertViewModel)
    {
        if (ModelState.IsValid)
        {
            TodoItem todoItem = new TodoItem();

            int statusId = upsertViewModel.Status;
            todoItem.Status = TodoItemStatus.From(upsertViewModel.Status);
            todoItem.Name = upsertViewModel.Name;
            todoItem.StartDate = upsertViewModel.StartDate;
            todoItem.DueDate = upsertViewModel.DueDate;
            todoItem.Note = upsertViewModel.Note;
            await _service.AddAsync(todoItem);
            return RedirectToAction(nameof(Index));
        }


        return View(upsertViewModel);
    }
    public async Task<IActionResult> ShowTodoItemDetail(int Id)
    {
        var data = await _service.GetByIdAsync(Id);
        UpsertViewModel upsertViewModel = new UpsertViewModel();
        var listStatus = await _statusService.ListAsync();
        ViewData["ListStatus"] = listStatus;
        upsertViewModel.Id = data.Id;
        upsertViewModel.Name = data.Name;
        upsertViewModel.Status = data.Status.Id;
        upsertViewModel.StartDate = data.StartDate;
        upsertViewModel.DueDate = data.DueDate;
        upsertViewModel.Note = data.Note;
        return View("TodoItemDetail", upsertViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateTodoItem(int id, UpsertViewModel upsertViewModel)
    {
        if (id != upsertViewModel.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            TodoItem todoItem = new TodoItem();
            todoItem.Id = upsertViewModel.Id;
            todoItem.Name = upsertViewModel.Name;
            todoItem.Status = TodoItemStatus.From(upsertViewModel.Status);
            todoItem.StartDate = upsertViewModel.StartDate;
            todoItem.DueDate = upsertViewModel.DueDate;
            todoItem.Note = upsertViewModel.Note;
            await _service.UpdateAsync(todoItem);
            return RedirectToAction(nameof(Index));
        }
        return View(upsertViewModel);
    }
    public async Task<IActionResult> Delete(int id)
    {
        TodoItem todoItem = new TodoItem();
        todoItem = await _service.DeleteAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }
        return RedirectToAction(nameof(Index));
    }
}