using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ministry.Migrations
{
    public partial class iniDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartCodeName",
                table: "tblFAQ");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tblFAQ",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MemberInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChamberId = table.Column<int>(type: "int", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Thana = table.Column<int>(type: "int", nullable: false),
                    Upzila = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tradelicense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alternative_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alternative_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Designaion = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberInfo");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tblFAQ");

            migrationBuilder.AddColumn<string>(
                name: "ApartCodeName",
                table: "tblFAQ",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
