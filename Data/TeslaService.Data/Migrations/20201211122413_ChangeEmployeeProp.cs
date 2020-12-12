using Microsoft.EntityFrameworkCore.Migrations;

namespace TeslaService.Data.Migrations
{
    public partial class ChangeEmployeeProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateOfJoin",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfJoin",
                table: "Employees");
        }
    }
}
