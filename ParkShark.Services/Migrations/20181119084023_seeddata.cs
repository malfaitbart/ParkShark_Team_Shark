using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class seeddata : Migration
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
                table: "Persons",
                columns: new[] { "Id", "EmailAdress", "MembershipId", "MobilePhone", "Name", "Phone", "RegistrationDate", "CityName", "PostalCode", "StreetName", "StreetNumber", "Country", "LicensePlateNumber" },
                values: new object[] { 1, "EmailAdress@test.be", null, "MobilePhone1", "Person1", null, null, "er", "4153", "tt", "1", "BXL", "000-000" });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "ID", "DirectorID", "Name", "OriginalName", "ParentDivisionId" },
                values: new object[] { 1, 1, "Division1", "Original1", null });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "Id", "BuildingTypeId", "Capacity", "ContactPersonId", "DivisionId", "Name", "PricePerHour", "CityName", "PostalCode", "StreetName", "StreetNumber" },
                values: new object[] { 1, 1, 50, 1, 1, "Lot1", 0m, "er", "4153", "tt", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildingTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BuildingTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
