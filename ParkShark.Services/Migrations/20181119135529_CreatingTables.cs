using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkShark.Services.Migrations
{
    public partial class CreatingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    EmailAdress = table.Column<string>(nullable: true),
                    LicensePlateNumber = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    MembershipId = table.Column<int>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OriginalName = table.Column<string>(nullable: true),
                    DirectorID = table.Column<int>(nullable: false),
                    ParentDivisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Divisions_Persons_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Divisions_Divisions_ParentDivisionId",
                        column: x => x.ParentDivisionId,
                        principalTable: "Divisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivisionId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    PricePerHour = table.Column<decimal>(nullable: false),
                    ContactPersonId = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    BuildingTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingLots_BuildingTypes_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingLots_Persons_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingLots_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allocations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MemberPeronId = table.Column<int>(nullable: false),
                    ParkinglotId = table.Column<int>(nullable: false),
                    StartingTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allocations_Persons_MemberPeronId",
                        column: x => x.MemberPeronId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Allocations_ParkingLots_ParkinglotId",
                        column: x => x.ParkinglotId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                values: new object[] { 1, null, null, "000", "test", "000", null, "er", "4153", "tt", "1", "BXL", "000-000" });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "ID", "DirectorID", "Name", "OriginalName", "ParentDivisionId" },
                values: new object[] { 1, 1, "Division1", "Original1", null });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "Id", "BuildingTypeId", "Capacity", "ContactPersonId", "DivisionId", "Name", "PricePerHour", "CityName", "PostalCode", "StreetName", "StreetNumber" },
                values: new object[] { 1, 1, 50, 1, 1, "Lot1", 0m, "er", "4153", "tt", "1" });

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_MemberPeronId",
                table: "Allocations",
                column: "MemberPeronId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_ParkinglotId",
                table: "Allocations",
                column: "ParkinglotId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_DirectorID",
                table: "Divisions",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ParentDivisionId",
                table: "Divisions",
                column: "ParentDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_BuildingTypeId",
                table: "ParkingLots",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_ContactPersonId",
                table: "ParkingLots",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_DivisionId",
                table: "ParkingLots",
                column: "DivisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allocations");

            migrationBuilder.DropTable(
                name: "ParkingLots");

            migrationBuilder.DropTable(
                name: "BuildingTypes");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
