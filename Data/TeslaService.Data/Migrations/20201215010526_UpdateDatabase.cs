using Microsoft.EntityFrameworkCore.Migrations;

namespace TeslaService.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Vehicles_VehicleId",
                table: "Insurances");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_BatteryId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_VehicleId",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Batteries");

            migrationBuilder.AlterColumn<string>(
                name: "InsuranceId",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BatteryId",
                table: "Vehicles",
                column: "BatteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_InsuranceId",
                table: "Vehicles",
                column: "InsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Insurances_InsuranceId",
                table: "Vehicles",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Insurances_InsuranceId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_BatteryId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_InsuranceId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "InsuranceId",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleId",
                table: "Insurances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleId",
                table: "Batteries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BatteryId",
                table: "Vehicles",
                column: "BatteryId",
                unique: true,
                filter: "[BatteryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_VehicleId",
                table: "Insurances",
                column: "VehicleId",
                unique: true,
                filter: "[VehicleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Vehicles_VehicleId",
                table: "Insurances",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
