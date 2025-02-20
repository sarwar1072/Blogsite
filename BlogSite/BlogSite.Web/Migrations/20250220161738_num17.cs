using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Visas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Policy",
                table: "Visas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638756866577515767");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638756866577515799");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5becf1f-0707-4f7d-b1da-b10328c633e3", "AQAAAAEAACcQAAAAEM2FBKHU7/6NX9u47dC81Z8DwbOsPZdMeYVU52l3ZZ4B8r4DppZbuWxz5PRiiPy+9g==", "918e74b1-1381-48d5-9a2e-12f768dcda48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a7f108e-54f2-457a-afb3-131e695242e3", "AQAAAAEAACcQAAAAEIXBVDgjlTCK5vriARPw4Qls5IqToVg9dBex7qQBo7J98SaKz4EOZ/oovwavXS+hKw==", "45463a5e-b592-411e-889e-0401655526da" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Visas");

            migrationBuilder.DropColumn(
                name: "Policy",
                table: "Visas");

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
    }
}
