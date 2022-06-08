using BDRD.DemoCICD.CRUDAPP.Web.Application;
using BDRD.DemoCICD.CRUDAPP.Web.Application.Repository;
using BDRD.DemoCICD.CRUDAPP.Web.Application.Service;
using BDRD.DemoCICD.CRUDAPP.Web.Database;
using BDRD.DemoCICD.CRUDAPP.Web.Extensions;
using BDRD.DemoCICD.CRUDAPP.Web.Hubs;
using BDRD.DemoCICD.CRUDAPP.Web.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(configuration.GetConnectionString("SqliteConnection")));
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
builder.Services.AddScoped<ITodoItemStatusService, TodoItemStatusService>();
builder.Services.AddScoped<ITodoItemStatusRepository, TodoItemStatusRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
//đoc file trong wwwroot
//cho phép truy cập các file trong wwwroot
//nếu UseFileServer thì bao gồm UseStaticFiles và khi truy cập vào đường dẫn root
// thì sẽ ra về file default (mặc định là là file index.html nếu có)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapHub<TodoItemHub>("/todoItemHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MigrateDbContext<AppDbContext>((context, services) =>
{
    var logger = services.GetRequiredService<ILogger<AppDbContextSeed>>();
    new AppDbContextSeed()
        .SeedAsync(context, logger)
        .Wait();
});

app.Run();
