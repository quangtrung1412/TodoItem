using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDApp.Web.Database.TodoMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_todo_item",
                columns: table => new
                {
                    todo_item_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    todo_item_name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    todo_item_status = table.Column<int>(type: "INTEGER", nullable: false),
                    todo_item_start_date = table.Column<DateTime>(type: "DATE", nullable: false, defaultValueSql: "(GETDATE())"),
                    todo_item_due_date = table.Column<DateTime>(type: "DATE", nullable: false, defaultValueSql: "(GETDATE())"),
                    todo_item_note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_todo_item_pk", x => x.todo_item_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_todo_item_status",
                columns: table => new
                {
                    todo_item_status_id = table.Column<int>(type: "INTEGER", nullable: false),
                    todo_item_status_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_todo_item_status_pk", x => x.todo_item_status_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_todo_item");

            migrationBuilder.DropTable(
                name: "tbl_todo_item_status");
        }
    }
}
