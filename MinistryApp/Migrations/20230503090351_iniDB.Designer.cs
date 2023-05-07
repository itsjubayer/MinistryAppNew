﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinistryApp.Models;

namespace Ministry.Migrations
{
    [DbContext(typeof(MinistryDBContext))]
    [Migration("20230503090351_iniDB")]
    partial class iniDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Ministry.Models.DistrictsVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bn_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Division_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("lat")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("lon")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DistrictsList");
                });

            modelBuilder.Entity("Ministry.Models.DivisionsVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("bn_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DivisionsList");
                });

            modelBuilder.Entity("Ministry.Models.DropDownValuesVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DropDownRef")
                        .HasColumnType("int");

                    b.Property<string>("DropDownText")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DropDownText");

                    b.Property<string>("DropDownValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DropDownValue");

                    b.Property<int>("EnumValueType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DropdownValues");
                });

            modelBuilder.Entity("Ministry.Models.FAQVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime");

                    b.Property<string>("EntryBy")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("FaqDescription")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FaqTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("tblFAQ");
                });

            modelBuilder.Entity("Ministry.Models.FileCategoryVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileCategoryName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FileCategoryName");

                    b.Property<string>("FileCategoryValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FileCategoryValue");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("FileCategoryList");
                });

            modelBuilder.Entity("Ministry.Models.FileModelVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Attachment")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DateLine")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<string>("FileCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FileName");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FilePath");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ResonsiblePerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SubmitStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SubmittedBy")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("SubmittedDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("application_usersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("application_usersId");

                    b.ToTable("tblFiles");
                });

            modelBuilder.Entity("Ministry.Models.MemberInfoVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Alternative_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alternative_Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChamberId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designaion")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("District")
                        .HasColumnType("int");

                    b.Property<int>("Division")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EntryDate")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("DateTime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MemberName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Thana")
                        .HasColumnType("int");

                    b.Property<string>("Tradelicense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Upzila")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MemberInfo");
                });

            modelBuilder.Entity("Ministry.Models.SubmittedFileVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Attachment")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ChamberPersonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Chamber_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Feedback_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Feedback_Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("File_Submit_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReSubmitDate")
                        .HasColumnType("DateTime");

                    b.Property<int>("Report_Type_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewedDate")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("Submission_Date")
                        .HasColumnType("DateTime");

                    b.Property<int?>("TypesOfReportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChamberPersonId");

                    b.HasIndex("TypesOfReportId");

                    b.ToTable("SubmittedFiles");
                });

            modelBuilder.Entity("Ministry.Models.TypesOfReportVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlertDays")
                        .HasColumnType("int");

                    b.Property<int>("AlertFrquency")
                        .HasColumnType("int");

                    b.Property<string>("Frequency_Of_Report")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Report_Type_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.ToTable("TypesOfReports");
                });

            modelBuilder.Entity("Ministry.Models.UnionsVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bn_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("upazilla_id")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UnionsList");
                });

            modelBuilder.Entity("Ministry.Models.UpazilasVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bn_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("district_id")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UpazilasList");
                });

            modelBuilder.Entity("MinistryApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Attachment")
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("ChamberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChamberNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("DateTime");

                    b.Property<int>("District")
                        .HasColumnType("int");

                    b.Property<int>("Division")
                        .HasColumnType("int");

                    b.Property<string>("ETIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseAttachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LicenseIssuedate")
                        .HasColumnType("DateTime");

                    b.Property<string>("LicenseNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LicenseRevokeDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("LicenseStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NID")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PassportNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Per_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Thana")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("TypesOfChambers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Upzila")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pre_Address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MinistryApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MinistryApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinistryApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MinistryApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ministry.Models.FileModelVM", b =>
                {
                    b.HasOne("MinistryApp.Models.ApplicationUser", "application_users")
                        .WithMany()
                        .HasForeignKey("application_usersId");

                    b.Navigation("application_users");
                });

            modelBuilder.Entity("Ministry.Models.SubmittedFileVM", b =>
                {
                    b.HasOne("MinistryApp.Models.ApplicationUser", "ChamberPerson")
                        .WithMany()
                        .HasForeignKey("ChamberPersonId");

                    b.HasOne("Ministry.Models.TypesOfReportVM", "TypesOfReport")
                        .WithMany()
                        .HasForeignKey("TypesOfReportId");

                    b.Navigation("ChamberPerson");

                    b.Navigation("TypesOfReport");
                });
#pragma warning restore 612, 618
        }
    }
}
