using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisaId",
                table: "UserForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_VisaId",
                table: "UserForms",
                column: "VisaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserForms_Visas_VisaId",
                table: "UserForms",
                column: "VisaId",
                principalTable: "Visas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserForms_Visas_VisaId",
                table: "UserForms");

            migrationBuilder.DropIndex(
                name: "IX_UserForms_VisaId",
                table: "UserForms");

            migrationBuilder.DropColumn(
                name: "VisaId",
                table: "UserForms");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638759275682949933");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638759275682949955");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4365c6c-32fc-4239-bd05-3730d1718976", "AQAAAAEAACcQAAAAEMBHh8MjABp5rAJDLnT4hrhaa9XHSkBu83e9JMHmotp1Z0DLm0w8CN85VtSzgejJYw==", "8c3984c9-839b-4f9e-b6ba-4f11aaca1f71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc5a2c1a-b67f-4595-af20-d78609258b93", "AQAAAAEAACcQAAAAEJi4edUDdJOwQWW0wY/z0iYri6SwWhxfVWjJsao7tCHo1W/IfXj1GZJ+GaHmpzuplw==", "588613f6-1c3c-4b1d-ade8-f9b7b520be21" });
        }
    }
}
