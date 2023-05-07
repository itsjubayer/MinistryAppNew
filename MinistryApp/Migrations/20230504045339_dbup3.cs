using Microsoft.EntityFrameworkCore.Migrations;

namespace Ministry.Migrations
{
    public partial class dbup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedFiles_AspNetUsers_ChamberPersonId",
                table: "SubmittedFiles");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedFiles_ChamberPersonId",
                table: "SubmittedFiles");

            migrationBuilder.DropColumn(
                name: "ChamberPersonId",
                table: "SubmittedFiles");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback_Note",
                table: "SubmittedFiles",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback_By",
                table: "SubmittedFiles",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Feedback_Note",
                table: "SubmittedFiles",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Feedback_By",
                table: "SubmittedFiles",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChamberPersonId",
                table: "SubmittedFiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedFiles_ChamberPersonId",
                table: "SubmittedFiles",
                column: "ChamberPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedFiles_AspNetUsers_ChamberPersonId",
                table: "SubmittedFiles",
                column: "ChamberPersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
