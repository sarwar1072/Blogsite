using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelFacilities_Hotels_HotelId",
                table: "HotelFacilities");

            migrationBuilder.DropIndex(
                name: "IX_HotelFacilities_HotelId",
                table: "HotelFacilities");

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

            migrationBuilder.CreateIndex(
                name: "IX_HotelFacilities_HotelId",
                table: "HotelFacilities",
                column: "HotelId",
                unique: true,
                filter: "[HotelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelFacilities_Hotels_HotelId",
                table: "HotelFacilities",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelFacilities_Hotels_HotelId",
                table: "HotelFacilities");

            migrationBuilder.DropIndex(
                name: "IX_HotelFacilities_HotelId",
                table: "HotelFacilities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638676422992171473");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638676422992171495");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7833885-b2a4-40b8-a751-60510ee68d8d", "AQAAAAEAACcQAAAAEJ1brMCV/Q8ijGhygtBA1gfklvPgOHNgokBX7DGMvIqhYUHnDVIJrfAANJ9vPuR6zQ==", "7db35313-73e7-49f9-82bc-be9dc5c17202" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cec518a-8783-47ea-bdb0-ee8dc401923b", "AQAAAAEAACcQAAAAEEJNLQ0CjVUxYOxR49nj6tvMkIYmhn2oTkprscFqA5+87y16CvHWtlGwJtscE6GZzg==", "fe76e3dc-e0a2-4575-97df-b5a163a412a0" });

            migrationBuilder.CreateIndex(
                name: "IX_HotelFacilities_HotelId",
                table: "HotelFacilities",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelFacilities_Hotels_HotelId",
                table: "HotelFacilities",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
