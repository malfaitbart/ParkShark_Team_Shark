using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class _04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_BuildingTypeId",
                table: "ParkingLots",
                column: "BuildingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_BuildingTypes_BuildingTypeId",
                table: "ParkingLots",
                column: "BuildingTypeId",
                principalTable: "BuildingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_BuildingTypes_BuildingTypeId",
                table: "ParkingLots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_BuildingTypeId",
                table: "ParkingLots");
        }
    }
}
