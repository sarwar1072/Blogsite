using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Tours_TourId",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638649683749729577");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638649683749729602");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ba70be4-09f8-4282-be41-e5beb4fa7dcb", "AQAAAAEAACcQAAAAEDBZqIdQXxqV1wTMKRmo55CoPNHivAK8wEZbSifZlyueoVzqdpsd6/AwEMs4WxEXcg==", "a31a4e0e-ca82-47a8-8a43-01c81eaa475c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd456e7a-d05d-4340-a749-8c525fbd7ab7", "AQAAAAEAACcQAAAAEIXRhhmrYJXDk3ML1W+yKzZVMiCp66jNXK6LhYnREhHCIt5AJKVfTmQ0zl2n2ewrmw==", "2d96b700-fb98-41e1-8044-c608023dd386" });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Tours_TourId",
                table: "Images",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Tours_TourId",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638648715733588037");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638648715733588057");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1986899c-82eb-45fc-8d36-d3440dd5aad7", "AQAAAAEAACcQAAAAEBbu6NNH7Ul3FDFRrmdco0SriUIvTWnGB1HXrvvj2q+PqCD2OcmbaTsJXvOZmUdFHg==", "dce42f7b-78fb-4be4-aa1b-43c04282520e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ee07a6f-acb1-49e2-80d8-f628026f2ab7", "AQAAAAEAACcQAAAAEAOjPiLV4t51KJPlc/agjj5vQb5Mx8kLqA1OiqMVtO89OLhYdC2qw+xWN6Qn4LDtoA==", "658b034a-b1f7-4baf-9f1e-73cc4bad22cc" });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Tours_TourId",
                table: "Images",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id");
        }
    }
}
