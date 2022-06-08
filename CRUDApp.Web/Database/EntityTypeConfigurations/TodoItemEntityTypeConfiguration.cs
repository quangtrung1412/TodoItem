using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDRD.DemoCICD.CRUDAPP.Web.Database.EntityTypeConfigurations;

class TodoItemEntityTypeConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("tbl_todo_item");
        builder.HasKey(e => e.Id)
        .HasName("tbl_todo_item_pk");

        builder.Property(e => e.Id)
        .HasColumnName("todo_item_id");
        builder.Property(e => e.Name)
        .HasColumnName("todo_item_name")
        .HasMaxLength(200)
        .IsRequired();
        builder.Property(e => e.StartDate)
        .HasColumnName("todo_item_start_date")
        .HasDefaultValueSql("(GETDATE())")
        .HasColumnType("DATE")
        .IsRequired();
        builder.Property(e => e.DueDate)
        .HasColumnName("todo_item_due_date")
        .HasDefaultValueSql("(GETDATE())")
        .HasColumnType("DATE")
        .IsRequired();
        builder.Property(e => e.Status)
        .HasColumnName("todo_item_status")
        .HasConversion(s => s.Id, s => TodoItemStatus.From(s))
        .IsRequired();
        builder.Property(e => e.Note)
        .HasColumnName("todo_item_note")
        .IsRequired(false);

    }
}