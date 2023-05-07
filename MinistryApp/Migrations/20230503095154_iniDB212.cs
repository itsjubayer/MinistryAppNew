using Microsoft.EntityFrameworkCore.Migrations;

namespace Ministry.Migrations
{
    public partial class iniDB212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FreqOfReport",
                table: "TypesOfReports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreqOfReport",
                table: "TypesOfReports");
        }
    }
}
