using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserForms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "UserForms",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638759302207111906");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638759302207111932");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae20ef83-8246-4593-b5a0-c8f667e09b6a", "AQAAAAEAACcQAAAAEDNxQKmAnHYPrCLVB0jD+4Y++bN+SPravI5dpa4uUNFhWf9uDx1M2ef35F3Gsb63JA==", "bb9bcf30-3086-4855-a827-5cce021a1e53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e36a2c1c-f490-43ce-a02b-f3527b579f36", "AQAAAAEAACcQAAAAECcS9E6HcclkGeF9cHzi47oUiZniVyk5zQwIbY34VefR9/fCSPemofa7KPpEe76R0g==", "2c4860ff-6bce-4ad5-a85d-361245b01376" });
        }
    }
}
