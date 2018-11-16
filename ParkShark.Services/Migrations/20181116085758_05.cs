using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class _05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Persons_DirectorID",
                table: "Divisions");

            migrationBuilder.AlterColumn<int>(
                name: "ContactPersonId",
                table: "ParkingLots",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DirectorID",
                table: "Divisions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_ContactPersonId",
                table: "ParkingLots",
                column: "ContactPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Persons_DirectorID",
                table: "Divisions",
                column: "DirectorID",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_Persons_ContactPersonId",
                table: "ParkingLots",
                column: "ContactPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Persons_DirectorID",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_Persons_ContactPersonId",
                table: "ParkingLots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_ContactPersonId",
                table: "ParkingLots");

            migrationBuilder.AlterColumn<int>(
                name: "ContactPersonId",
                table: "ParkingLots",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DirectorID",
                table: "Divisions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Persons_DirectorID",
                table: "Divisions",
                column: "DirectorID",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
