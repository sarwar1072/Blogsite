using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.CreateTable(
                name: "Visas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaValidity = table.Column<int>(type: "int", nullable: true),
                    ProcessingTime = table.Column<int>(type: "int", nullable: true),
                    MaxiMumStay = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638756658553480645");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638756658553480672");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76ff8c77-6893-4b0a-9890-4fbd0520598f", "AQAAAAEAACcQAAAAEHZV8ph7dAjZrTZYfKPYggT9yBPUI6msmg20o0FY4NvjMr4/KzuLp9Xc8v5WTvvp6g==", "f01cb14e-703f-4507-8ae0-6d6e2b93a4bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff3ba15c-03a7-4a48-92c8-fb3ea6db0797", "AQAAAAEAACcQAAAAEEgQtKjFcOU3enIwdJ6uwe9WRyIML8MoQV2D5qpGHJojAVKhb/Duk3RStW13rfVdnA==", "91c1b8c1-2bad-476a-b7c2-88fe4c5ba7c5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visas");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SeatsAvailable = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638755708342775316");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638755708342775338");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25ac45c4-4882-4deb-9692-654198699388", "AQAAAAEAACcQAAAAECGfNTYGTWAmAeKpj3ttJiIy5+fp8qAa2pq9UA++PXwPYtoiql7G3DWskA0DsFFNrw==", "cb6ae72d-9802-40e0-8733-2b44b0df8563" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c38aaacb-8be8-448f-9ed9-825c52e84c89", "AQAAAAEAACcQAAAAEKHvEj4K3yyrVW2VNJRYRlkt+/HiWDmntzbS98ukPTZTLs1I/U86EWJo5e4UUMEOiQ==", "ac554647-161e-4fb5-ae69-fa12ec52a6b0" });
        }
    }
}
