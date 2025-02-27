using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelBookings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638762822975574085");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638762822975574118");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8e361b8-6335-43de-a94f-0f8e2e0f1f2f", "AQAAAAEAACcQAAAAEMefO4/kRXVSVKpb+F9TAP+rX26kKhLz68ocIjdseyZD2pDBbmJt9XZ6IU/Lq8WvSQ==", "30d487e0-e454-41cd-8252-5adc47767d10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ddb6d3-6afc-43d3-a724-cd43022442e5", "AQAAAAEAACcQAAAAEABEkreSZgKScmjQG1+21rXoxASNSQpJVHXQaC6jGemrGyTzowiuRTYZbj80uTUW9A==", "06c07f32-5635-4acd-836b-836b48f66b4b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelBookings");

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
    }
}
