using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638667075361999902");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638667075361999930");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c3b7f91-11dd-4fa7-89ae-6256b08eb40c", "AQAAAAEAACcQAAAAEOYHv+xLNPd/k2tZHgq5G7VQuTv0px/+vZf6ZJvIAzDDnNofVN3vEVsTDTR3x6n5JQ==", "9fea7cda-ba76-4f98-9d39-78ac7140d0a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "829018be-501e-4628-a195-dcbf73536433", "AQAAAAEAACcQAAAAEEExkMdVZZHjsTak3oQBwro7DTPzINNKcyE1LBJXCea5ZD1Y6vo7VqF4R4L6i/X9JA==", "614e71dd-3f6a-42ec-8a19-df5dac0a31c4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638667072691297189");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638667072691297215");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed0bf36-b9ac-4677-8dfe-7cc1883a63a5", "AQAAAAEAACcQAAAAEKzaYbh4NpH/zFhuv1xFnuN1R03K2zTbJXQE+5+Y58PlDXreEaX5SlwUgXn7oT9KGQ==", "351b5d8d-5204-4506-9122-020409346283" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2862ac7-7c60-4e9d-a7df-ad71e14a5f4a", "AQAAAAEAACcQAAAAEEZk0vOgV66T2AGctcyUfGvhNt5455l7zccVs6FLysxd/CsUWC1fzKxm2zR7YYtS1g==", "b9f7d533-9e40-44fa-8ca6-97e19bbb6eaa" });
        }
    }
}
