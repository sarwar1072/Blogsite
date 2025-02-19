using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638755708342775316");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638755708342775338");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25ac45c4-4882-4deb-9692-654198699388", "sarwar", null, "AQAAAAEAACcQAAAAECGfNTYGTWAmAeKpj3ttJiIy5+fp8qAa2pq9UA++PXwPYtoiql7G3DWskA0DsFFNrw==", "cb6ae72d-9802-40e0-8733-2b44b0df8563" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c38aaacb-8be8-448f-9ed9-825c52e84c89", "Admin", null, "AQAAAAEAACcQAAAAEKHvEj4K3yyrVW2VNJRYRlkt+/HiWDmntzbS98ukPTZTLs1I/U86EWJo5e4UUMEOiQ==", "ac554647-161e-4fb5-ae69-fa12ec52a6b0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638680051619160637");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638680051619160670");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6543c66-b510-4361-a448-37f9e680bb63", "sarwar", "AQAAAAEAACcQAAAAEBW0UGb20RqQUEid27KycYpY3TZ92PZj4aGpPC/F9le0XR1fAINaRcwmvW8dM+VTHQ==", "62876eeb-b6e0-4f41-b8da-6f6518fc2522" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash", "SecurityStamp" },
                values: new object[] { "927d1991-8017-4e98-9f9c-909de2cb2b01", "Admin", "AQAAAAEAACcQAAAAEECqjWrHjeK/WvMlqBMonM8lEqoBX2siB3EMwyAu0x7pKzpScrH2CknqZG/GnC69YQ==", "e2b91860-9aa0-43a4-a485-3e27e5267068" });
        }
    }
}
