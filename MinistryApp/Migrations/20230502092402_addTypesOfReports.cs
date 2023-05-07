using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ministry.Migrations
{
    public partial class addTypesOfReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesOfReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Report_Type_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Frequency_Of_Report = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    AlertDays = table.Column<int>(type: "int", nullable: false),
                    AlertFrquency = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chamber_Id = table.Column<int>(type: "int", nullable: false),
                    ChamberPersonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Report_Type_Id = table.Column<int>(type: "int", nullable: false),
                    TypesOfReportId = table.Column<int>(type: "int", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Submission_Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ReviewedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    File_Submit_Status = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ReSubmitDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Feedback_Note = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Feedback_By = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedFiles_AspNetUsers_ChamberPersonId",
                        column: x => x.ChamberPersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittedFiles_TypesOfReports_TypesOfReportId",
                        column: x => x.TypesOfReportId,
                        principalTable: "TypesOfReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedFiles_ChamberPersonId",
                table: "SubmittedFiles",
                column: "ChamberPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedFiles_TypesOfReportId",
                table: "SubmittedFiles",
                column: "TypesOfReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmittedFiles");

            migrationBuilder.DropTable(
                name: "TypesOfReports");
        }
    }
}
