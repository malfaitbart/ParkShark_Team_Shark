using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class _07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ParentDivisionId",
                table: "Divisions",
                column: "ParentDivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Divisions_ParentDivisionId",
                table: "Divisions",
                column: "ParentDivisionId",
                principalTable: "Divisions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Divisions_ParentDivisionId",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_ParentDivisionId",
                table: "Divisions");
        }
    }
}
