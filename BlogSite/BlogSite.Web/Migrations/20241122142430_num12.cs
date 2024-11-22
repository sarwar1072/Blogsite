using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638679038707112016");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638679038707112038");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69f93fd8-41ea-4b29-a569-fe39a181965b", "AQAAAAEAACcQAAAAEKGzxEo2w/z5XczdsAPPYtqVQhmVsr43YeWdli2jkk//QdlpTS8A03shZbC4jN7zlg==", "3868e267-4c8a-46d0-bd86-00df5d2d3e26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ddef4a0-b05c-49d3-a857-36b0e30684d7", "AQAAAAEAACcQAAAAEN5cmeOdEoOHrDB6rf0TAdaOuyORg9T58wlQBWbr9ln+ckNwP8g3l9X+uZI4nKNNdg==", "88bc2919-6f96-4a2b-a433-f25dec4d5ef2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638676429855313937");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638676429855313960");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb455503-487c-4cb8-8e5c-c278274bba5a", "AQAAAAEAACcQAAAAEH+mRbrBCeZxCxfWdIpS0ZDD7YTn4h3FJCT0XX1dJAv2evg8vkbCVk0yw8WbdputAA==", "6ce3ef77-7935-4220-b300-7c4f9e877688" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d7a9249-0efd-4890-9652-857d1a155b1b", "AQAAAAEAACcQAAAAEP+d299UukIBzzyGTmtRHuc6bGFpIHDueyM+zrpKEQA6aRr8xZt7CKdMpv+4eldy2g==", "55cb5d6a-c165-4df3-8112-55689e3fcbf2" });
        }
    }
}
