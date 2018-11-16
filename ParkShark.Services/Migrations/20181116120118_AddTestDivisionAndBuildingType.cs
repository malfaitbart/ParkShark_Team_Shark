using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class AddTestDivisionAndBuildingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BuildingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Underground" });

            migrationBuilder.InsertData(
                table: "BuildingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "AboveGround" });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "ID", "DirectorID", "Name", "OriginalName", "ParentDivisionId" },
                values: new object[] { 1, 1, "Division1", "Original1", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildingTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BuildingTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
