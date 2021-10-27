using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false),
                    MajorId = table.Column<string>(nullable: true),
                    IsEnabledMentor = table.Column<bool>(nullable: false),
                    IsDisable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectMajor",
                columns: table => new
                {
                    SubjectId = table.Column<string>(nullable: false),
                    MajorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectMajor", x => new { x.MajorId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_SubjectMajor_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectMajor_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Mentor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    IsGraduted = table.Column<bool>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    MajorId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mentor_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mentor_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Deposit = table.Column<double>(nullable: false),
                    Withdraw = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    MentorId = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectMentors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MentorId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectMentors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectMentors_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectMentors_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentRegistration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentRegistration_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistration_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    File = table.Column<byte[]>(nullable: true),
                    SubjectMentorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resource_SubjectMentors_SubjectMentorId",
                        column: x => x.SubjectMentorId,
                        principalTable: "SubjectMentors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "STUDENT", "STUDENT", "STUDENT", "STUDENT" },
                    { "MENTOR", "MENTOR", "MENTOR", "MENTOR" },
                    { "ADMIN", "ADMIN", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Balance", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fullname", "Gender", "IsDisable", "IsEnabledMentor", "LockoutEnabled", "LockoutEnd", "MajorId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3c5ec754-01b1-49cf-94e0-09250222b060", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "980649f3-b44d-44fd-ad5a-d188fc949368", null, false, "Admin Ne`", null, false, false, false, null, null, null, "admin", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "6ac8bcff-4753-4f62-8bd2-9eeda2eb239c", false, "admin" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b062", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "97ae136f-db23-40ec-8401-94f3ba843984", null, false, "Mr. Emp2", null, false, false, false, null, null, null, "emp2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "8602e840-3683-4097-8b6f-01aa8e743057", false, "emp2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b063", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6ed844a8-c52e-4b8f-9b92-10890b9fc494", null, false, "Mr. Emp3", null, false, false, false, null, null, null, "emp3", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "416a0655-af21-4da0-89d6-21908e4fbfba", false, "emp3" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b064", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5821311f-e870-4c96-84e7-daa9504c109d", null, false, "Mr. Emp4", null, false, false, false, null, null, null, "emp4", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "b86f0d0f-9bd3-4992-9d42-0f298b574459", false, "emp4" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b065", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2d84d799-c5f3-4478-9e25-9098898b9dea", null, false, "Mr. Emp5", null, false, false, false, null, null, null, "emp5", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "6b03e96d-872b-40f4-9a73-d08d292e3ad4", false, "emp5" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b066", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "74e04604-9166-4d2d-a267-5289a2970670", null, false, "Mr. Loc", null, false, false, false, null, null, null, "loc", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "7da1c7d5-bd37-47e6-93f9-086bce02cb5d", false, "loc" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b067", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7c7e6fc2-14d2-474e-9cda-664e1e22d43d", null, false, "Mr. Tam", null, false, false, false, null, null, null, "tam", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "1215536c-4dda-4330-ac68-e3158d8bc9dc", false, "tam" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b068", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fcd0fcdd-c399-40a3-a488-d219e9fcbdb2", null, false, "Mr. Emp6", null, false, false, false, null, null, null, "emp6", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "2790e526-e171-4637-ac3d-7517d9a25937", false, "emp6" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b069", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ce3229ad-4323-4ace-8382-060209471382", null, false, "Mr. Emp7", null, false, false, false, null, null, null, "emp7", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "95782c0a-0b69-47eb-9642-fe570c6a3978", false, "emp7" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b070", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4459c637-4a5c-4c2b-843d-2216a1da8809", null, false, "Mr. Emp8", null, false, false, false, null, null, null, "emp8", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "64be416d-a7f3-4849-add4-d6127e14d873", false, "emp8" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b071", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b09ba3bd-4fb1-4201-bf9d-dc88bbba482d", null, false, "Mr. Emp9", null, false, false, false, null, null, null, "emp9", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "e8df0939-5e82-4dbe-82f4-73d3967886a4", false, "emp9" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b073", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8357e033-7b75-4e5a-a776-437d2a66d6c7", null, false, "Mr. Loc1", null, false, false, false, null, null, null, "loc1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "8b8d0885-370c-4340-99e0-831e55520577", false, "loc1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b074", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0c7a284c-f236-4771-a13c-d993b80c388a", null, false, "Mr. Tam1", null, false, false, false, null, null, null, "tam1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "5f7b1e5d-99b7-4f0a-bd3e-8b2ed85420d7", false, "tam1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b075", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9e78b50b-054f-4217-a203-6a3c3fa37c20", null, false, "Mr. Emp11", null, false, false, false, null, null, null, "emp11", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "729259ba-ac67-45a3-b590-7548439b7962", false, "emp11" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b076", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f15cf7ab-b5b0-41fc-89fc-08b49f3ae32d", null, false, "Mr. Emp12", null, false, false, false, null, null, null, "emp12", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "80b7a5f7-e3c3-42e6-8a33-ad4e9a524d90", false, "emp12" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b077", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "70270b4d-1055-4d55-9fda-67b0d424c744", null, false, "Mr. Emp13", null, false, false, false, null, null, null, "emp13", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "6fb7f4b3-5251-4210-8bff-2faa65fc10fe", false, "emp13" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b078", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0f941c25-c35e-4e0c-8028-7c68c5756455", null, false, "Mr. Emp14", null, false, false, false, null, null, null, "emp14", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "605218a5-6280-40e7-bf29-4dd9122f989b", false, "emp14" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b079", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c80e24f7-0dcb-4f34-b354-27a06f28d800", null, false, "Mr. Emp15", null, false, false, false, null, null, null, "emp15", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "7f39f263-0d06-4b01-bc18-5fdd8cc2d321", false, "emp15" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b080", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3b0b188a-6aa8-415b-a5ea-7dc2f8e653cd", null, false, "Mr. Loc2", null, false, false, false, null, null, null, "loc2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "24a52112-8109-4ecb-a540-e2e4bee3fe88", false, "loc2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b081", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7414204d-4cf6-4739-ba68-0ea7f4bcc664", null, false, "Mr. Tam2", null, false, false, false, null, null, null, "tam2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "f7470b15-509b-48b0-81d1-90bc7ffbebfa", false, "tam2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b061", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "370adc20-33ac-4394-ae9f-03df5b9d93b7", null, false, "Mr. Emp1", null, false, false, false, null, null, null, "emp1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "e72c9f6c-18a1-4758-bcac-a5efb35cfa96", false, "emp1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b072", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0c4b8993-2d1f-4e3f-aded-317666e8d750", null, false, "Mr. Emp10", null, false, false, false, null, null, null, "emp10", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "8d2386c6-4bde-4822-8e03-1aad0d2fe43b", false, "emp10" }
                });

            migrationBuilder.InsertData(
                table: "Major",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "SE", new DateTime(2021, 10, 27, 23, 6, 18, 757, DateTimeKind.Local).AddTicks(6678), new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(8515), null, false, "Software Engineering" },
                    { "SB", new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9643), new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9647), null, false, "Economic" },
                    { "SA", new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9665), new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9666), null, false, "English" },
                    { "CN", new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9668), new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9669), null, false, "Chinese" },
                    { "SJ", new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9671), new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9672), null, false, "Japanese" },
                    { "GD", new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9674), new DateTime(2021, 10, 27, 23, 6, 18, 758, DateTimeKind.Local).AddTicks(9675), null, false, "Graphic Design" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "GDS003", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4662), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4663), null, false, "Design Advance" },
                    { "PRJ001", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4002), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4009), null, false, "Java OOP" },
                    { "PRJ002", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4577), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4581), null, false, "Java Desktop" },
                    { "PRJ003", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4611), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4612), null, false, "Java Web" },
                    { "PRF001", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4614), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4615), null, false, "C" },
                    { "PRF002", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4617), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4618), null, false, "C++" },
                    { "PRF003", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4620), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4621), null, false, "C#" },
                    { "ENG001", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4623), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4624), null, false, "English 1" },
                    { "ENG002", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4626), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4627), null, false, "English 2" },
                    { "ENG003", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4628), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4629), null, false, "English 3" },
                    { "JPN001", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4631), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4632), null, false, "Japanese 1" },
                    { "JPN002", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4634), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4635), null, false, "Japanese 2" },
                    { "JPN003", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4637), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4638), null, false, "Japanese 3" },
                    { "CNN001", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4639), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4640), null, false, "Chinese 1" },
                    { "CNN002", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4642), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4643), null, false, "Chinese 2" },
                    { "CNN003", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4645), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4646), null, false, "Chinese 3" },
                    { "MKT001", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4648), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4649), null, false, "Marketing 1" },
                    { "MKT002", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4651), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4652), null, false, "Marketing 2" },
                    { "MKT003", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4653), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4655), null, false, "Marketing 3" },
                    { "GDS001", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4656), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4657), null, false, "History of Graphic Design" },
                    { "GDS002", new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4659), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(4660), null, false, "Design Basic" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "3c5ec754-01b1-49cf-94e0-09250222b081", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b060", "ADMIN" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b061", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b062", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b063", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b064", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b068", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b069", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b070", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b071", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b065", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b075", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b072", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b074", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b073", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b067", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b066", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b080", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b078", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b077", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b076", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b079", "MENTOR" }
                });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "Id", "About", "Company", "IsGraduted", "MajorId", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219391"), null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219399"), null, null, false, "SB", 0, "3c5ec754-01b1-49cf-94e0-09250222b072" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219398"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b071" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), null, null, false, "SB", 0, "3c5ec754-01b1-49cf-94e0-09250222b071" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219396"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b070" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), null, null, false, "GD", 0, "3c5ec754-01b1-49cf-94e0-09250222b070" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b069" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219393"), null, null, false, "GD", 0, "3c5ec754-01b1-49cf-94e0-09250222b069" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), null, null, false, "CN", 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), null, null, false, "CN", 0, "3c5ec754-01b1-49cf-94e0-09250222b072" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219390"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219388"), null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b065" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), null, null, false, "CN", 0, "3c5ec754-01b1-49cf-94e0-09250222b065" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219380"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b061" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b062" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219382"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b062" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b061" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219384"), null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b063" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219385"), null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b064" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219386"), null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b064" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219387"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b065" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b063" }
                });

            migrationBuilder.InsertData(
                table: "SubjectMajor",
                columns: new[] { "MajorId", "SubjectId" },
                values: new object[,]
                {
                    { "SA", "ENG003" },
                    { "SE", "PRJ002" },
                    { "SE", "PRJ003" },
                    { "SE", "PRF001" },
                    { "SE", "PRF002" },
                    { "SE", "PRF003" },
                    { "SA", "ENG001" },
                    { "SA", "ENG002" },
                    { "SJ", "JPN001" },
                    { "SB", "MKT001" },
                    { "SJ", "JPN003" },
                    { "CN", "CNN001" },
                    { "CN", "CNN002" },
                    { "CN", "CNN003" },
                    { "SB", "MKT002" },
                    { "SB", "MKT003" },
                    { "GD", "GDS001" },
                    { "GD", "GDS002" },
                    { "GD", "GDS003" },
                    { "SJ", "JPN002" },
                    { "SE", "PRJ001" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "MentorId", "Name", "Price", "Rating", "StartDate", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e336"), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(6873), new DateTime(2021, 10, 27, 23, 6, 18, 759, DateTimeKind.Local).AddTicks(6879), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 1", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e352"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9494), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9495), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 17", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e351"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9483), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9484), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 16", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e356"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9536), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9537), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 21", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e355"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9526), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9527), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 20", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e344"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9410), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9411), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), "Course 9", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e354"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9515), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9516), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219393"), "Course 19", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e349"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9462), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9463), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), "Course 14", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e347"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9441), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9442), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219391"), "Course 12", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e353"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9504), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9505), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219399"), "Course 18", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e343"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9398), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9399), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219390"), "Course 8", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e346"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9430), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9432), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219388"), "Course 11", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e342"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9387), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9388), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219387"), "Course 7", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e345"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9420), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9421), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219386"), "Course 10", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e341"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9376), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9377), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 6", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e338"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9333), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9334), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 3", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e340"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9364), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9365), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), "Course 5", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e337"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9193), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9212), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), "Course 2", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e339"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9350), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9351), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 4", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e348"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9452), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9453), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), "Course 13", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e350"), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9473), new DateTime(2021, 10, 27, 23, 6, 18, 761, DateTimeKind.Local).AddTicks(9474), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), "Course 15", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN003" }
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
                name: "IX_AspNetUsers_MajorId",
                table: "AspNetUsers",
                column: "MajorId");

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
                name: "IX_Course_MentorId",
                table: "Course",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubjectId",
                table: "Course",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentor_MajorId",
                table: "Mentor",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentor_UserId",
                table: "Mentor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_SectionId",
                table: "Question",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_StudentId",
                table: "Question",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_SubjectMentorId",
                table: "Resource",
                column: "SubjectMentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CourseId",
                table: "Section",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistration_CourseId",
                table: "StudentRegistration",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistration_StudentId",
                table: "StudentRegistration",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectMajor_SubjectId",
                table: "SubjectMajor",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectMentors_MentorId",
                table: "SubjectMentors",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectMentors_SubjectId",
                table: "SubjectMentors",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");
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
                name: "Question");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "StudentRegistration");

            migrationBuilder.DropTable(
                name: "SubjectMajor");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "SubjectMentors");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Mentor");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Major");
        }
    }
}
