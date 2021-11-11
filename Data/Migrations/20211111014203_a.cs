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
                    AvatarUrl = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    MajorId = table.Column<string>(nullable: true)
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
                name: "AvailableMajor",
                columns: table => new
                {
                    MajorId = table.Column<string>(nullable: false),
                    MentorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableMajor", x => new { x.MajorId, x.MentorId });
                    table.ForeignKey(
                        name: "FK_AvailableMajor_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableMajor_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Rating = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    MentorId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<string>(nullable: true),
                    MajorId = table.Column<string>(nullable: true),
                    IsEnroll = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { "3c5ec754-01b1-49cf-94e0-09250222b060", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "16b3f929-8658-49a3-9293-fdc3e2a9ef0a", null, false, "Admin Ne`", null, false, false, false, null, null, null, "admin", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "4358bd0b-ce35-48d4-b754-c13dd91661d1", false, "admin" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b062", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00ddac40-3387-4602-9e27-c50a97a7b950", null, false, "Mr. Emp2", null, false, false, false, null, null, null, "emp2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "37000380-6bdc-4de2-b794-8dc5ee4122f6", false, "emp2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b063", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "22791c8e-059f-4b91-9330-7a89c7a28f31", null, false, "Mr. Emp3", null, false, false, false, null, null, null, "emp3", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "5c625751-d217-49a4-b2a2-083065876a37", false, "emp3" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b064", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "61b2b797-efe1-4613-9b7c-c9e365fecfb3", null, false, "Mr. Emp4", null, false, false, false, null, null, null, "emp4", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "123ea644-ce68-49a0-a390-584b8ac532a2", false, "emp4" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b065", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "13b5f03b-483c-4398-addc-45921dedb4d9", null, false, "Mr. Emp5", null, false, false, false, null, null, null, "emp5", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "39cdf8c9-c82f-4dc2-9ece-b3e6294f742f", false, "emp5" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b066", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7dbff86f-c7c6-4f33-99d4-23b2f10a506e", null, false, "Mr. Loc", null, false, false, false, null, null, null, "loc", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "1184b801-4393-4d97-8d66-dca12f7e5d9b", false, "loc" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b067", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "97658a91-4d66-4bf6-92a0-707b4698e239", null, false, "Mr. Tam", null, false, false, false, null, null, null, "tam", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "41196733-a2f7-47de-b42f-e40f209ffbc9", false, "tam" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b068", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4b125b17-8661-41af-99bd-dfbec5c8245e", null, false, "Mr. Emp6", null, false, false, false, null, null, null, "emp6", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "e406b8a6-7daf-401c-9c62-0c4f776428fa", false, "emp6" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b069", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7e62d59-4f9b-45a9-9c0e-b1918e8c690c", null, false, "Mr. Emp7", null, false, false, false, null, null, null, "emp7", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "5112537b-485a-4284-ba5d-21021008c9c1", false, "emp7" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b070", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5fbe88f1-e1f0-4855-be3c-ba61416f93b0", null, false, "Mr. Emp8", null, false, false, false, null, null, null, "emp8", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "7a0d4c1a-edfa-4f39-ae25-0d0330cfa2bd", false, "emp8" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b071", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c3a41167-d66b-4ae3-ab2b-0b406230d5ac", null, false, "Mr. Emp9", null, false, false, false, null, null, null, "emp9", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "27d853b1-372e-42e8-bd68-c730cfc043fa", false, "emp9" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b073", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9439ba8c-494f-466f-ab57-316a46af4321", null, false, "Mr. Loc1", null, false, false, false, null, null, null, "loc1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "a3406bc7-12e4-4e48-9de9-2e976724344c", false, "loc1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b074", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03dd0078-2e38-423c-bc37-4b517c6705c1", null, false, "Mr. Tam1", null, false, false, false, null, null, null, "tam1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "f6b9b776-aa0f-4d0d-9206-d523c55e2729", false, "tam1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b075", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "308792a0-4f8a-4140-a54b-0136befda063", null, false, "Mr. Emp11", null, false, false, false, null, null, null, "emp11", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "6cdcfd6f-712d-4d3e-a414-4b535aa5bed2", false, "emp11" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b076", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e7b5f162-92b1-4dca-be74-c4d17210d30c", null, false, "Mr. Emp12", null, false, false, false, null, null, null, "emp12", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "d82bf97e-57b4-4277-ad4a-fdd158690c75", false, "emp12" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b077", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "28a3a2fc-6add-4b1e-bd2f-6bf9ae1ca212", null, false, "Mr. Emp13", null, false, false, false, null, null, null, "emp13", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "b843b061-2e46-4456-ad97-66f3c1e17d03", false, "emp13" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b078", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "11c98a5f-0c4e-43a8-ae7b-7d79bb5b2cb0", null, false, "Mr. Emp14", null, false, false, false, null, null, null, "emp14", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "792ce431-1858-4f65-bf64-e1158d1125d4", false, "emp14" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b079", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "61c5903f-b26a-44f3-946d-2823e1535249", null, false, "Mr. Emp15", null, false, false, false, null, null, null, "emp15", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "2511e3d2-d9a8-4257-bc43-db2d70994d8d", false, "emp15" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b080", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "842463db-0020-4bbd-bbcb-2e3adfdb7680", null, false, "Mr. Loc2", null, false, false, false, null, null, null, "loc2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "7e8a17c8-93ce-408a-97fd-9a533d716b5c", false, "loc2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b081", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bd6fc6ca-0d57-461b-b419-ab3baf8f801e", null, false, "Mr. Tam2", null, false, false, false, null, null, null, "tam2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "a90a879a-5e58-4576-ab3d-3dec0e751326", false, "tam2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b061", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3c14db28-6aa9-4d3d-b9fd-81acd51370da", null, false, "Mr. Emp1", null, false, false, false, null, null, null, "emp1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "8dbab0d8-9cf5-43fb-a57d-0a91793d59ed", false, "emp1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b072", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fa65f83b-9cd4-434a-b12c-c17b0681ac96", null, false, "Mr. Emp10", null, false, false, false, null, null, null, "emp10", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "3e58abf2-8681-4886-ba3c-8292188d28a5", false, "emp10" }
                });

            migrationBuilder.InsertData(
                table: "Major",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "SE", new DateTime(2021, 11, 11, 8, 42, 2, 463, DateTimeKind.Local).AddTicks(7533), new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(6407), null, false, "Software Engineering" },
                    { "SB", new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7447), new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7453), null, false, "Economic" },
                    { "SA", new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7473), new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7474), null, false, "English" },
                    { "CN", new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7530), new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7532), null, false, "Chinese" },
                    { "SJ", new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7535), new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7536), null, false, "Japanese" },
                    { "GD", new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7538), new DateTime(2021, 11, 11, 8, 42, 2, 464, DateTimeKind.Local).AddTicks(7539), null, false, "Graphic Design" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "GDS003", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4436), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4437), null, false, "Design Advance" },
                    { "PRJ001", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(3737), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(3744), null, false, "Java OOP" },
                    { "PRJ002", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4269), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4273), null, false, "Java Desktop" },
                    { "PRJ003", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4298), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4299), null, false, "Java Web" },
                    { "PRF001", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4301), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4302), null, false, "C" },
                    { "PRF002", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4304), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4305), null, false, "C++" },
                    { "PRF003", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4307), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4308), null, false, "C#" },
                    { "ENG001", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4310), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4311), null, false, "English 1" },
                    { "ENG002", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4313), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4314), null, false, "English 2" },
                    { "ENG003", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4399), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4401), null, false, "English 3" },
                    { "JPN001", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4403), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4404), null, false, "Japanese 1" },
                    { "JPN002", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4406), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4407), null, false, "Japanese 2" },
                    { "JPN003", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4409), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4410), null, false, "Japanese 3" },
                    { "CNN001", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4412), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4413), null, false, "Chinese 1" },
                    { "CNN002", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4415), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4416), null, false, "Chinese 2" },
                    { "CNN003", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4418), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4419), null, false, "Chinese 3" },
                    { "MKT001", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4421), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4422), null, false, "Marketing 1" },
                    { "MKT002", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4424), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4425), null, false, "Marketing 2" },
                    { "MKT003", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4427), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4428), null, false, "Marketing 3" },
                    { "GDS001", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4430), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4431), null, false, "History of Graphic Design" },
                    { "GDS002", new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4433), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(4434), null, false, "Design Basic" }
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
                    { "3c5ec754-01b1-49cf-94e0-09250222b065", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b068", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b069", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b071", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b070", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b075", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b076", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b077", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b078", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b079", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b066", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b067", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b073", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b074", "STUDENT" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b072", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b080", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "Id", "About", "AvatarUrl", "Company", "IsGraduted", "MajorId", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b069" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b072" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b071" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b070" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219385"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b064" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b063" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219382"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b062" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b061" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), null, null, null, false, null, 0, "3c5ec754-01b1-49cf-94e0-09250222b065" }
                });

            migrationBuilder.InsertData(
                table: "SubjectMajor",
                columns: new[] { "MajorId", "SubjectId" },
                values: new object[,]
                {
                    { "SE", "PRJ002" },
                    { "SE", "PRJ003" },
                    { "SE", "PRF001" },
                    { "SE", "PRF002" },
                    { "SE", "PRF003" },
                    { "SA", "ENG001" },
                    { "SA", "ENG002" },
                    { "SA", "ENG003" },
                    { "SJ", "JPN001" },
                    { "CN", "CNN001" },
                    { "SJ", "JPN003" },
                    { "CN", "CNN002" },
                    { "CN", "CNN003" },
                    { "SB", "MKT001" },
                    { "SB", "MKT002" },
                    { "SB", "MKT003" },
                    { "GD", "GDS001" },
                    { "GD", "GDS002" },
                    { "GD", "GDS003" },
                    { "SJ", "JPN002" },
                    { "SE", "PRJ001" }
                });

            migrationBuilder.InsertData(
                table: "AvailableMajor",
                columns: new[] { "MajorId", "MentorId" },
                values: new object[,]
                {
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219379") },
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219400") },
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219397") },
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219395") },
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219394") },
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219389") },
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219385") },
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219392") },
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219383") },
                    { "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219382") }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Duration", "ImageUrl", "IsDeleted", "IsEnroll", "MajorId", "MentorId", "Name", "Price", "Rating", "StartDate", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e341"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7119), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7120), null, null, null, false, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 6", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e336"), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(6510), new DateTime(2021, 11, 11, 8, 42, 2, 465, DateTimeKind.Local).AddTicks(6516), "ABC FCK", "2 week", null, false, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 1", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e352"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7190), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7192), null, null, null, false, false, "SB", new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 17", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e351"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7179), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7180), null, null, null, false, false, "SB", new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 16", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e339"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7102), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7103), null, null, null, false, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 4", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e356"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7212), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7213), null, null, null, false, false, "GD", new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 21", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e355"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7201), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7202), null, null, null, false, false, "GD", new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 20", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e338"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(6993), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7001), null, null, null, false, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 3", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e344"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7132), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7133), null, null, null, false, false, "SA", new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), "Course 9", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e349"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7156), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7157), null, null, null, false, false, "CN", new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), "Course 14", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e350"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7167), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7168), null, null, null, false, false, "CN", new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), "Course 15", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e348"), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7144), new DateTime(2021, 11, 11, 8, 42, 2, 471, DateTimeKind.Local).AddTicks(7145), null, null, null, false, false, "CN", new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), "Course 13", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN001" }
                });

            migrationBuilder.InsertData(
                table: "SubjectMentors",
                columns: new[] { "Id", "MentorId", "Name", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("3f0c7479-25cd-4815-962e-a317ab219394"), new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), "English 2", "PRJ003" },
                    { new Guid("3f0c7479-25cd-4800-962e-a317ab219379"), new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Java OOP", "PRJ001" },
                    { new Guid("3f0c7479-25cd-4810-962e-a317ab219389"), new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), "Chinese 1", "PRJ003" },
                    { new Guid("3f0c7479-25cd-4816-962e-a317ab219395"), new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Design Basic", "PRJ003" },
                    { new Guid("3f0c7479-25cd-4803-962e-a317ab219382"), new Guid("3f0c7479-25cd-4863-962e-a317ab219382"), "English 2", "PRJ003" },
                    { new Guid("3f0c7479-25cd-4806-962e-a317ab219385"), new Guid("3f0c7479-25cd-4863-962e-a317ab219385"), "Java OOP", "PRJ001" },
                    { new Guid("3f0c7479-25cd-4818-962e-a317ab219397"), new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "English 1", "PRJ003" },
                    { new Guid("3f0c7479-25cd-4804-962e-a317ab219383"), new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Java Web", "PRJ003" },
                    { new Guid("3f0c7479-25cd-4813-962e-a317ab219392"), new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), "Chinese 2", "PRJ003" },
                    { new Guid("3f0c7479-25cd-4821-962e-a317ab219400"), new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), "Marketing 2", "PRJ003" }
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
                name: "IX_AvailableMajor_MentorId",
                table: "AvailableMajor",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_MajorId",
                table: "Course",
                column: "MajorId");

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
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "AvailableMajor");

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
