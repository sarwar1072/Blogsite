using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TourDetailsId",
                table: "Tours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638661002502733868");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638661002502733891");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8da75fe-fa77-4fcb-a0e7-f9f8b0b9d618", "AQAAAAEAACcQAAAAEFow3X9mPxLAH0OUQPhiOtqTENC0ofeTz1lIUsPmwsh2kIqcVCUynMJC7QiKjkGHEQ==", "341efacc-42f0-4b17-abe6-7a5671639702" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c0bd7a7-d34b-4fad-b2a2-671e616e1a4f", "AQAAAAEAACcQAAAAEOaikVNnsafLdEAdkGC45AshmLXssM6nm+MBgjOrTA6wPgO2gko3zAwYLBP5Mx8HGQ==", "e3eef3d5-25b0-468b-902b-97d0f10ff5cd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TourDetailsId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638660830679312459");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638660830679312491");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04384bf0-a5f7-443a-99d2-bb914052168b", "AQAAAAEAACcQAAAAEOtuSb4UDwM3i5HG/+HLEgaDc/vh3D/4/n1TGg4oODCIrdeCfGhJt/uOX4iSMDJH3A==", "93ad2ad6-c334-41f5-ad88-b0f7920bdba0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7477720a-7ffa-45b2-a28e-70a60105bc06", "AQAAAAEAACcQAAAAEP3qpIyLvzXVh8wNJIj6BrRDDGMlxM8NduPvmvOeXDD0ofq2KADTH9ic/IYHnQZBPQ==", "78cd8ebd-2cfc-466b-a8e6-9173118c26ae" });
        }
    }
}
