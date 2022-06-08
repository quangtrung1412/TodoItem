using BDRD.DemoCICD.CRUDAPP.Web.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDRD.DemoCICD.CRUDAPP.Web.Database.EntityTypeConfigurations;

class TodoItemStatusEntityTypeConfiguration : IEntityTypeConfiguration<TodoItemStatus>
{
    public void Configure(EntityTypeBuilder<TodoItemStatus> builder)
    {
        builder.ToTable("tbl_todo_item_status");
        builder.HasKey(e => e.Id)
        .HasName("tbl_todo_item_status_pk");

        builder.Property(e => e.Id)
        .HasColumnName("todo_item_status_id")
        .ValueGeneratedNever();

        builder.Property(e => e.Name)
        .HasColumnName("todo_item_status_name")
        .HasMaxLength(100)
        .IsRequired();
    }
}