using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class AddTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "Id", "BuildingTypeId", "Capacity", "ContactPersonId", "DivisionId", "Name", "PricePerHour", "CityName", "PostalCode", "StreetName", "StreetNumber" },
                values: new object[] { 1, 1, 50, 1, 1, "Lot1", 0m, "er", "4153", "tt", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
