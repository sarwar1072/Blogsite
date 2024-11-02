using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Web.Migrations
{
    public partial class num3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultationForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredJourneyDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationForms", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638661726119018809");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638661726119018856");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "267ef944-7f73-4d6a-90ae-f77966e53d71", "AQAAAAEAACcQAAAAEFGhrh8bq92VwPz+z6D+qf1eyc+KSW64F2Ah18M0/Jfj2y17PghTh2f7fsqJvoretg==", "1926b292-1b5b-41a6-85d0-5779035faaf3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "737f5460-2e46-4976-b14e-6ad0da5a5b29", "AQAAAAEAACcQAAAAEKgKmFWMehPFi7KgL+FfWBR0ch8pIBEVV+MUJ1P0btuJlbXkUTv5ALGDYX8RHGEVNw==", "d4c27d18-1a64-4f4a-98cc-2cefa59ecc2b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultationForms");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638661002502733868");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638661002502733891");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8da75fe-fa77-4fcb-a0e7-f9f8b0b9d618", "AQAAAAEAACcQAAAAEFow3X9mPxLAH0OUQPhiOtqTENC0ofeTz1lIUsPmwsh2kIqcVCUynMJC7QiKjkGHEQ==", "341efacc-42f0-4b17-abe6-7a5671639702" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c0bd7a7-d34b-4fad-b2a2-671e616e1a4f", "AQAAAAEAACcQAAAAEOaikVNnsafLdEAdkGC45AshmLXssM6nm+MBgjOrTA6wPgO2gko3zAwYLBP5Mx8HGQ==", "e3eef3d5-25b0-468b-902b-97d0f10ff5cd" });
        }
    }
}
