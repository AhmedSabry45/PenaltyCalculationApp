using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PenaltyCalculation.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    HolidayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayId);
                    table.ForeignKey(
                        name: "FK_Holidays_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Currency", "Name" },
                values: new object[,]
                {
                    { 1, "TR", "Turkey" },
                    { 2, "AE", "United Arab Emirates" },
                    { 3, "TW", "China " },
                    { 4, "DE", "German" },
                    { 5, "DK", "Denmark" },
                    { 6, "US", "UnitedState" },
                    { 7, "FR", "France" },
                    { 8, "IT", "Italy" },
                    { 9, "JP", "Japan" },
                    { 10, "KR", "Korea" },
                    { 11, "RU", "Russia" },
                    { 12, "IN", "India" },
                    { 13, "EG", "Egypt" }
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "HolidayId", "CountryId", "Date", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eid" });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "HolidayId", "CountryId", "Date", "Name" },
                values: new object[] { 2, 1, new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eid" });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "HolidayId", "CountryId", "Date", "Name" },
                values: new object[] { 3, 1, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eid" });

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_CountryId",
                table: "Holidays",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
