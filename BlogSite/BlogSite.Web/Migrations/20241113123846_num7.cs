using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBooking_Rooms_RoomId",
                table: "HotelBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBooking",
                table: "HotelBooking");

            migrationBuilder.RenameTable(
                name: "HotelBooking",
                newName: "HotelBookings");

            migrationBuilder.RenameIndex(
                name: "IX_HotelBooking_RoomId",
                table: "HotelBookings",
                newName: "IX_HotelBookings_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBookings",
                table: "HotelBookings",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638671199266384106");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638671199266384128");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bd808b5-6aff-4753-8fcd-df8d3ff3a7a4", "AQAAAAEAACcQAAAAEC320tbST2ZYyA/ZS8r4dhowmm8OAvqZNDdNbcK/h2JaQ1lkumuu+2wYAgRlEargBA==", "2c95a90a-9d27-4674-b428-c1cc58a44c92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d08c798c-2169-48c9-b0ac-568e2f9445c8", "AQAAAAEAACcQAAAAEKi3KXr/T5B/ppp/1U87JtpL9eThsEKUMSeyqYGuuiZJzq14HOF1TzoEY+LJcouw7A==", "83eda425-b31e-43a6-99e3-87e38ab08f53" });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBookings_Rooms_RoomId",
                table: "HotelBookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBookings_Rooms_RoomId",
                table: "HotelBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBookings",
                table: "HotelBookings");

            migrationBuilder.RenameTable(
                name: "HotelBookings",
                newName: "HotelBooking");

            migrationBuilder.RenameIndex(
                name: "IX_HotelBookings_RoomId",
                table: "HotelBooking",
                newName: "IX_HotelBooking_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBooking",
                table: "HotelBooking",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638671194960590832");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638671194960590864");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "205ce5c5-4230-4e52-a68f-fd7b3b688898", "AQAAAAEAACcQAAAAEGzusEv5yXa/J3s+UR3qJR8VqYx75CAnmAYD0X+CyNbAFfLyttSiGiSnizhkxr5+WA==", "b76ad5d9-651d-43c0-88d3-9977cdccd761" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8d1447e-aa11-4eee-8857-269853ad8598", "AQAAAAEAACcQAAAAEGxvlEqbohCntPMV3BUDtGX4DtWyTAUXQxkb/PtW3AW82MjLKfnjZFqvLReHLK+zUg==", "6e4f9d7c-4ddf-479b-9c46-d4737f200f9d" });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBooking_Rooms_RoomId",
                table: "HotelBooking",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
