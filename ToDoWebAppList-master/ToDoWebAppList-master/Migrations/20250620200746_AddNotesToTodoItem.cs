using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoWebAppList.Migrations
{
    /// <inheritdoc />
    public partial class AddNotesToTodoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TodoItems",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TodoItems");
        }
    }
}
