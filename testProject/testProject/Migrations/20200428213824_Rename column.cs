using Microsoft.EntityFrameworkCore.Migrations;

namespace testProject.Migrations
{
    public partial class Renamecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "message",
                table: "Messages",
                newName: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "Messages",
                newName: "message");
        }
    }
}
