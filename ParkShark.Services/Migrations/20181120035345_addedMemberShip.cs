using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class addedMemberShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberShips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MonthlyCost = table.Column<double>(nullable: false),
                    AllocationCost = table.Column<double>(nullable: false),
                    MaxAllocationTime = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShips", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MembershipId",
                table: "Persons",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_MemberShips_MembershipId",
                table: "Persons",
                column: "MembershipId",
                principalTable: "MemberShips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_MemberShips_MembershipId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "MemberShips");

            migrationBuilder.DropIndex(
                name: "IX_Persons_MembershipId",
                table: "Persons");
        }
    }
}
