using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Policies",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomFacilities",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Policies",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomFacilities",
                table: "Rooms");

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
                value: "638671199266384106");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638671199266384128");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bd808b5-6aff-4753-8fcd-df8d3ff3a7a4", "AQAAAAEAACcQAAAAEC320tbST2ZYyA/ZS8r4dhowmm8OAvqZNDdNbcK/h2JaQ1lkumuu+2wYAgRlEargBA==", "2c95a90a-9d27-4674-b428-c1cc58a44c92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d08c798c-2169-48c9-b0ac-568e2f9445c8", "AQAAAAEAACcQAAAAEKi3KXr/T5B/ppp/1U87JtpL9eThsEKUMSeyqYGuuiZJzq14HOF1TzoEY+LJcouw7A==", "83eda425-b31e-43a6-99e3-87e38ab08f53" });
        }
    }
}
