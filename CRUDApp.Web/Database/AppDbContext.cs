using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
using BDRD.DemoCICD.CRUDAPP.Web.Database.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BDRD.DemoCICD.CRUDAPP.Web.Database;

#nullable disable
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<TodoItemStatus> TodoItemStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoItemStatusEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TodoItemEntityTypeConfiguration());
    }
}