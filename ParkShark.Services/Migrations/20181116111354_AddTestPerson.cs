using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class AddTestPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "EmailAdress", "LicensePlateId", "MembershipId", "MobilePhone", "Name", "Phone", "RegistrationDate", "CityName", "PostalCode", "StreetName", "StreetNumber" },
                values: new object[] { 1, "EmailAdress@test.be", null, null, "MobilePhone1", "Person1", null, null, "er", "4153", "tt", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
