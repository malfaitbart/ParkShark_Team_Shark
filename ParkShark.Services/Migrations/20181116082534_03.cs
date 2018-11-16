using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonAddress_PersonId",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_DivisionId",
                table: "ParkingLots",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_Divisions_DivisionId",
                table: "ParkingLots",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_Divisions_DivisionId",
                table: "ParkingLots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_DivisionId",
                table: "ParkingLots");

            migrationBuilder.AddColumn<int>(
                name: "PersonAddress_PersonId",
                table: "Persons",
                nullable: false,
                defaultValue: 0);
        }
    }
}
