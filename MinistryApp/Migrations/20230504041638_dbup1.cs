using Microsoft.EntityFrameworkCore.Migrations;

namespace Ministry.Migrations
{
    public partial class dbup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "chamber_username",
                table: "SubmittedFiles",
                type: "nvarchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "chamber_username",
                table: "SubmittedFiles");
        }
    }
}
