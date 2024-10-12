using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Tours");

            migrationBuilder.AddColumn<string>(
                name: "CancellationTerm",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MapUrl",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxiMumPeople",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MiniMumPeople",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638643673758032806");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638643673758032836");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6b9d2b3-6cc7-4791-9ac1-c038db6c670c", "AQAAAAEAACcQAAAAEFoTzdJ1wEUmyDbgO2Vu7gCFGAkN+3fjDbqHdddglyy1YYnHjQrWHeEkV5INLAOzrA==", "a52c58a8-5384-4015-9189-dc30ff050354" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31b0162f-b2dd-4eaf-ad16-3fb622f589c1", "AQAAAAEAACcQAAAAEEeSDiqnY+IES3YROy19PgNO7vZ/nfLfC5SjG/IX2h2Fuea/KqN+B8bvfyiemQ1UVw==", "ea55c64f-be61-4511-a8f7-b99d4075b1a3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancellationTerm",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "MapUrl",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "MaxiMumPeople",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "MiniMumPeople",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Tours");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638643490857100837");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638643490857100864");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "606285b7-ec1e-435e-baca-508458eee91b", "AQAAAAEAACcQAAAAEPQRg423WpxGV6Qudi/ItcCPHDNhy7sgi7Rf1V/wbyG8NJpedhR9bws6kJNQNiz6lg==", "9f037fea-9f7c-4d4e-af47-f7504fec2c12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40539506-1071-409c-9b9f-e66213b7f16d", "AQAAAAEAACcQAAAAEJMrcpGueRK5dvohE5anVzkodx0xc0RhaC1Ib6GU3sVG0j/3CzQeLrRv5EdsEA78Wg==", "74615b55-dea1-4eab-af11-4cc8e4402e64" });
        }
    }
}
