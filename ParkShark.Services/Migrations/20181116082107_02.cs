using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlAddress_ParkinglotId",
                table: "ParkingLots");

            migrationBuilder.AddColumn<int>(
                name: "PersonAddress_PersonId",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_DirectorID",
                table: "Divisions",
                column: "DirectorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Persons_DirectorID",
                table: "Divisions",
                column: "DirectorID",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Persons_DirectorID",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_DirectorID",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "PersonAddress_PersonId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "PlAddress_ParkinglotId",
                table: "ParkingLots",
                nullable: false,
                defaultValue: 0);
        }
    }
}
