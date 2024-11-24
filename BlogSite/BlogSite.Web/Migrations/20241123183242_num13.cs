using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AirportTransfer",
                table: "HotelBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BedType",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DecorationsInRoom",
                table: "HotelBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExtraBed",
                table: "HotelBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NoteToProperty",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGuests",
                table: "HotelBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "RoomOnHigherFloor",
                table: "HotelBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoomPreference",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6543c66-b510-4361-a448-37f9e680bb63", "AQAAAAEAACcQAAAAEBW0UGb20RqQUEid27KycYpY3TZ92PZj4aGpPC/F9le0XR1fAINaRcwmvW8dM+VTHQ==", "62876eeb-b6e0-4f41-b8da-6f6518fc2522" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "927d1991-8017-4e98-9f9c-909de2cb2b01", "AQAAAAEAACcQAAAAEECqjWrHjeK/WvMlqBMonM8lEqoBX2siB3EMwyAu0x7pKzpScrH2CknqZG/GnC69YQ==", "e2b91860-9aa0-43a4-a485-3e27e5267068" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirportTransfer",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "BedType",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "DecorationsInRoom",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "ExtraBed",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "NoteToProperty",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "NumberOfGuests",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "RoomOnHigherFloor",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "RoomPreference",
                table: "HotelBookings");

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
    }
}
