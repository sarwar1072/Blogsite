using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hotelfacilities",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Policy",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638676332104854558");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638676332104854580");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc6076a8-29f8-4950-800e-65b5758dde2b", "AQAAAAEAACcQAAAAECJJ5RSkOIKRy1JdtOAvhEToxHMRmszTCuNh8+5RAqx/HouK32LQplrZwQZyg11+UA==", "569a131a-84a9-4827-9223-ac81b7f7f720" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e37c9543-b8c0-4fba-8b5d-64ef75908fff", "AQAAAAEAACcQAAAAEKf8EVkuoFQ4OwFQ2rtob6Nj7JKXCPUYZvSE7guPIDrWgugcFdHqvBis16pxJ8EyAA==", "c4dc34da-5b82-4492-8520-ee4f4cd34ff9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hotelfacilities",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Policy",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638675755418503982");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638675755418504004");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9689cfe1-5af5-4ead-97a5-893ea44bd928", "AQAAAAEAACcQAAAAEGr1XW3xYi1X+hq9sMUFi+UW7Q4zo3+qSBp71KqZWpOhaeaLpgKcBhWxz3sCfw/s8g==", "dc48c381-77c3-403e-92ee-ea0265b17d9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9191877-19ba-4634-8832-5977ed02f5ba", "AQAAAAEAACcQAAAAED0mKPjLPzqPz4hA6KHgY6LV0oPjOr6+7TjSAd+G7M9atrFp1RXnZTBA2wGEjZn/Wg==", "94efc6a9-428e-4f4d-aaaa-4f40506cf3ff" });
        }
    }
}
