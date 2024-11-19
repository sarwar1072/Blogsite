using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FitnessFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    General = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndoorFacitilies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Policies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFacilities_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638676422992171473");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638676422992171495");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7833885-b2a4-40b8-a751-60510ee68d8d", "AQAAAAEAACcQAAAAEJ1brMCV/Q8ijGhygtBA1gfklvPgOHNgokBX7DGMvIqhYUHnDVIJrfAANJ9vPuR6zQ==", "7db35313-73e7-49f9-82bc-be9dc5c17202" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cec518a-8783-47ea-bdb0-ee8dc401923b", "AQAAAAEAACcQAAAAEEJNLQ0CjVUxYOxR49nj6tvMkIYmhn2oTkprscFqA5+87y16CvHWtlGwJtscE6GZzg==", "fe76e3dc-e0a2-4575-97df-b5a163a412a0" });

            migrationBuilder.CreateIndex(
                name: "IX_HotelFacilities_HotelId",
                table: "HotelFacilities",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelFacilities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638676332104854558");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638676332104854580");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc6076a8-29f8-4950-800e-65b5758dde2b", "AQAAAAEAACcQAAAAECJJ5RSkOIKRy1JdtOAvhEToxHMRmszTCuNh8+5RAqx/HouK32LQplrZwQZyg11+UA==", "569a131a-84a9-4827-9223-ac81b7f7f720" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e37c9543-b8c0-4fba-8b5d-64ef75908fff", "AQAAAAEAACcQAAAAEKf8EVkuoFQ4OwFQ2rtob6Nj7JKXCPUYZvSE7guPIDrWgugcFdHqvBis16pxJ8EyAA==", "c4dc34da-5b82-4492-8520-ee4f4cd34ff9" });
        }
    }
}
