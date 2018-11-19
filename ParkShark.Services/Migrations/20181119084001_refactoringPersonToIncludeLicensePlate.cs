using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class refactoringPersonToIncludeLicensePlate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlateId",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicensePlateNumber",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LicensePlateNumber",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "LicensePlateId",
                table: "Persons",
                nullable: true);
        }
    }
}
