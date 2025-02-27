using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProcessStatus",
                table: "UserForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638762446858773152");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638762446858773267");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b95a0cc5-e467-4aca-971e-dc12bfcb9d52", "AQAAAAEAACcQAAAAELfgwqfArf/+9m435MoEbYN/SSyodXraOYfM5C7iStbnrB37B2L6URBwFGAy7h77eg==", "834b2916-7b11-4cb9-94ab-09a50a75837f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "392ecf12-d819-4e44-90cf-37b8825770b7", "AQAAAAEAACcQAAAAEOZHwq8jPw9Tuec5iTpc7MNJ+OuQkUwwMR6tJajrO2G/+PwbjqUBzaxN/LCYIw7Z6g==", "8a75f00d-698d-46d5-bdf0-0064bd04093a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessStatus",
                table: "UserForms");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638759333580094256");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638759333580094285");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3083fa4-5181-4d29-ade0-c07f2bfce058", "AQAAAAEAACcQAAAAEMv+oJgx02mvSFGDrAGc0qFBvSWp5RYuex1/4h1+mo3i1Uj6H85Y2LLVwZmUQ9khAg==", "d3852cdc-26eb-4a49-950e-1762dee369da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5da5a36-5978-4b44-9ecc-3a1943490da7", "AQAAAAEAACcQAAAAELDAa04+FEaS9sufGGB1et4GjyEYnpmxlTC68vCjUcmdw7jhpM82MDat9ETndV0jKg==", "33cfc12b-d4ed-4aba-8997-3cec4bd52026" });
        }
    }
}
