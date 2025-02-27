using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "HotelBookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638762830885643860");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638762830885643883");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e912277-3461-4b26-80aa-087268e89dc8", "AQAAAAEAACcQAAAAEMzXMKjDn3UAHzJoeAvlOAV1D5b3etatbHCFDZ+RkyNdco3/AUnipzZBe493/jfU+Q==", "f790ede1-833a-4d55-8c76-eeef622c3eef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2da72ac8-f482-4ad3-85dc-766dd3b2501c", "AQAAAAEAACcQAAAAEGax2Wv0SlL7pI9jxn5Ei2CR2NeSlm1+wm1uCoNLQEnfKXTnDSHDUiTME3sOQCOhiw==", "7c4be7b2-4da3-4397-bc9c-27afd91a8d6b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HotelBookings");

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
    }
}
