using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ministry.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChamberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypesOfChambers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChamberNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thana = table.Column<int>(type: "int", nullable: false),
                    Upzila = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseIssuedate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LicenseRevokeDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LicenseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ETIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "DateTime", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Per_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pre_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(55)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistrictsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Division_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Bn_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    lat = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    lon = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DivisionsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    bn_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DropdownValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropDownText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropDownValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropDownRef = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EnumValueType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropdownValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileCategoryList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileCategoryValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileCategoryList", x => x.Id);
                });

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
                    Designation = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFAQ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaqTitle = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FaqDescription = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EntryBy = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFAQ", x => x.Id);
                });

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
                    Remarks = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FreqOfReport = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnionsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upazilla_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Bn_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnionsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpazilasList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    district_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Bn_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpazilasList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FileCategory = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    DateLine = table.Column<DateTime>(type: "DateTime", nullable: false),
                    SubmitStatus = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ResonsiblePerson = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(250)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    SubmittedBy = table.Column<string>(type: "varchar(250)", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    application_usersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblFiles_AspNetUsers_application_usersId",
                        column: x => x.application_usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chamber_Id = table.Column<int>(type: "int", nullable: false),
                    Report_Type_Id = table.Column<int>(type: "int", nullable: false),
                    TypesOfReportId = table.Column<int>(type: "int", nullable: false),
                    chamber_username = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Submission_Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ReviewedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    File_Submit_Status = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ReSubmitDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Feedback_Note = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FeedbackDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Feedback_By = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedFiles_TypesOfReports_TypesOfReportId",
                        column: x => x.TypesOfReportId,
                        principalTable: "TypesOfReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedFiles_TypesOfReportId",
                table: "SubmittedFiles",
                column: "TypesOfReportId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFiles_application_usersId",
                table: "tblFiles",
                column: "application_usersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DistrictsList");

            migrationBuilder.DropTable(
                name: "DivisionsList");

            migrationBuilder.DropTable(
                name: "DropdownValues");

            migrationBuilder.DropTable(
                name: "FileCategoryList");

            migrationBuilder.DropTable(
                name: "MemberInfo");

            migrationBuilder.DropTable(
                name: "SubmittedFiles");

            migrationBuilder.DropTable(
                name: "tblFAQ");

            migrationBuilder.DropTable(
                name: "tblFiles");

            migrationBuilder.DropTable(
                name: "UnionsList");

            migrationBuilder.DropTable(
                name: "UpazilasList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TypesOfReports");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
