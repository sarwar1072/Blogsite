using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumberOfTravellers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicationUserid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfTravellers = table.Column<int>(type: "int", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserForms_AspNetUsers_applicationUserid",
                        column: x => x.applicationUserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_applicationUserid",
                table: "UserForms",
                column: "applicationUserid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserForms");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTravellers",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638759094733182164");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638759094733182186");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab251d14-e576-4400-9214-5b1c8f7d6e0a", "AQAAAAEAACcQAAAAEN31yoXLn5yprcHvqlyHHrOHETGEJfDxAvdjwGsJSu1Q9AQa29AhxjutZRn9h1xmzQ==", "efd4ccec-1d83-4517-879a-be26dd1bb3fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f329dec0-9b73-4a35-8444-728eb0cc0266", "AQAAAAEAACcQAAAAEHX+PtmVgkaCZWGWn9OpbyrxAKgMA5CFdRsDrLkpmeuHiAECp/ZL1sjdDGOM51Q8Pg==", "231bd51c-416d-48bc-97ee-49e975feeda3" });
        }
    }
}
