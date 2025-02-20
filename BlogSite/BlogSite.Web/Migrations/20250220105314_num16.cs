using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardUrl",
                table: "Visas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverUrl",
                table: "Visas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638756671939936282");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638756671939936308");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57386e33-e072-4746-8386-9e9fd4f42ce5", "AQAAAAEAACcQAAAAEHGbRpj4G+T0NMz5GxaaYMZIrIUTFaF4lN2Fe2uP8Mc3tpXVWIwEm2iQrs6ipI+C4g==", "6dbd16d7-bdea-4e3e-ab8d-25ce61405d6e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c75ceac1-d92e-4d01-b3f6-af82eae132ed", "AQAAAAEAACcQAAAAEJgSWpFvrHMnM9S0CR+yUHC7QS6BTY6VVKvj0CEK75pxTFizhEuZ17vJbCpBEQcb6w==", "a1b47eb7-4616-4540-aafc-58f521bc6d91" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardUrl",
                table: "Visas");

            migrationBuilder.DropColumn(
                name: "CoverUrl",
                table: "Visas");

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
    }
}
