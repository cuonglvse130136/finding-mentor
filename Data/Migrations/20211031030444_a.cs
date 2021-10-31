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
                    MentorId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true),
                    MajorId = table.Column<string>(nullable: true)
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
                        name: "FK_Course_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IsDisable = table.Column<bool>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
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
                name: "Mentor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    IsGraduted = table.Column<bool>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true),
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
                columns: new[] { "Id", "AccessFailedCount", "Address", "Balance", "BirthDate", "ConcurrencyStamp", "CourseId", "Email", "EmailConfirmed", "Fullname", "Gender", "IsDisable", "IsEnabledMentor", "LockoutEnabled", "LockoutEnd", "MajorId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3c5ec754-01b1-49cf-94e0-09250222b060", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ab77950c-b6f7-4920-bceb-866fba7c296c", null, null, false, "Admin Ne`", null, false, false, false, null, null, null, "admin", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "752daee0-9b8d-4e5c-835f-a6645fbe6591", false, "admin" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b062", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8c52f5bd-158b-43fc-b3ef-360cb9429e5c", null, null, false, "Mr. Emp2", null, false, false, false, null, null, null, "emp2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "db7236ac-e34d-41a3-8440-218d990b7d00", false, "emp2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b063", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7d303414-d5d4-4286-8763-f22cdadbb9a4", null, null, false, "Mr. Emp3", null, false, false, false, null, null, null, "emp3", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "1b56ae2e-86e0-4e31-bb76-9746629ea25e", false, "emp3" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b064", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f67427d2-3564-47f6-8ef3-24ad4eed46f5", null, null, false, "Mr. Emp4", null, false, false, false, null, null, null, "emp4", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "cfbf5a76-392a-4400-a27e-ba569b87f60a", false, "emp4" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b065", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a9dec058-7771-4c4d-967f-7197dbeef4c9", null, null, false, "Mr. Emp5", null, false, false, false, null, null, null, "emp5", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "bb572006-d99a-4e38-841e-67c0b19b052f", false, "emp5" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b066", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0a96786d-26d3-43b6-a390-248b8a9f7158", null, null, false, "Mr. Loc", null, false, false, false, null, null, null, "loc", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "42e93f20-df28-4644-8445-b6c26a279188", false, "loc" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b067", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3dadff30-17d9-4ac0-bed9-938928ce04e3", null, null, false, "Mr. Tam", null, false, false, false, null, null, null, "tam", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "848e5a62-bb48-4401-bcb8-02a6b2c2159c", false, "tam" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b068", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a8ac3d71-d586-4871-ab77-d055b445e1cb", null, null, false, "Mr. Emp6", null, false, false, false, null, null, null, "emp6", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "a54591c8-202f-4a02-b75e-dd36993ce20e", false, "emp6" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b069", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "712a669f-b805-4b25-bd58-e6d2df825d5f", null, null, false, "Mr. Emp7", null, false, false, false, null, null, null, "emp7", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "67a27002-52b2-4530-ad63-9119b5e45c75", false, "emp7" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b070", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d1c25037-f86b-4177-8bcb-155e42962c02", null, null, false, "Mr. Emp8", null, false, false, false, null, null, null, "emp8", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "fb06db59-b0ab-48d5-a377-bc1ab2dc19c9", false, "emp8" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b071", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "80c7c2db-f41c-4b46-a59b-1c309692646e", null, null, false, "Mr. Emp9", null, false, false, false, null, null, null, "emp9", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "fac14a28-c4ce-4fb1-b5ce-c8ca508a8440", false, "emp9" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b073", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b083b217-8a20-4dcb-b899-ab818457efc8", null, null, false, "Mr. Loc1", null, false, false, false, null, null, null, "loc1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "ca7db0a6-e69e-4908-b365-9998a98f8e03", false, "loc1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b074", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5361964d-e2f2-4ea9-8129-963087512066", null, null, false, "Mr. Tam1", null, false, false, false, null, null, null, "tam1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "4cc9a10b-2aaa-463d-9a76-578b89ab50f3", false, "tam1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b075", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "594d2018-28eb-4e52-9200-991daa7c561d", null, null, false, "Mr. Emp11", null, false, false, false, null, null, null, "emp11", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "5a8843d9-4a4c-407e-adfd-5c438e63e59b", false, "emp11" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b076", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d34d9547-871e-452a-b124-ac54c4ab928e", null, null, false, "Mr. Emp12", null, false, false, false, null, null, null, "emp12", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "7f29ca89-9031-419d-8bad-be2106a648bc", false, "emp12" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b077", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e5b23af1-edaa-4ec6-86c5-0480675ad012", null, null, false, "Mr. Emp13", null, false, false, false, null, null, null, "emp13", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "332b49e0-28c4-49d4-94f9-039f576c8b13", false, "emp13" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b078", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "552676cb-f5f0-4a0a-8898-1af40dd466b6", null, null, false, "Mr. Emp14", null, false, false, false, null, null, null, "emp14", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "93a1885b-a57d-4f0a-b2d5-5cc31033fb0f", false, "emp14" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b079", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ab1be6dc-fafb-45e5-9a43-6c980f663121", null, null, false, "Mr. Emp15", null, false, false, false, null, null, null, "emp15", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "04df3edb-e421-4d64-8fd6-dc0ec60584e9", false, "emp15" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b080", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "91a0eb0f-a080-4127-b5c2-941c13bdca29", null, null, false, "Mr. Loc2", null, false, false, false, null, null, null, "loc2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "066e0be3-835a-41a5-9183-d8d0f8dcae4b", false, "loc2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b081", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "768f6ea8-9db8-4094-9683-57a01cdd1056", null, null, false, "Mr. Tam2", null, false, false, false, null, null, null, "tam2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "d260958a-c826-48b9-8876-f37248647c89", false, "tam2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b061", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "653e2016-6d5c-4551-bcb9-9b4e94a63278", null, null, false, "Mr. Emp1", null, false, false, false, null, null, null, "emp1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "986015d6-74ce-43ce-9205-6251863251fe", false, "emp1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b072", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d6a09dff-3af9-4296-a4e1-a43da4e4ebb2", null, null, false, "Mr. Emp10", null, false, false, false, null, null, null, "emp10", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "58f29ed0-39d4-4edc-a90f-e78c8f5c381c", false, "emp10" }
                });

            migrationBuilder.InsertData(
                table: "Major",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "SE", new DateTime(2021, 10, 31, 10, 4, 44, 95, DateTimeKind.Local).AddTicks(1325), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(185), null, false, "Software Engineering" },
                    { "SB", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(963), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(967), null, false, "Economic" },
                    { "SA", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(983), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(984), null, false, "English" },
                    { "CN", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(985), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(987), null, false, "Chinese" },
                    { "SJ", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(988), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(989), null, false, "Japanese" },
                    { "GD", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(991), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(992), null, false, "Graphic Design" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "GDS003", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7125), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7127), null, false, "Design Advance" },
                    { "PRJ001", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(6417), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(6424), null, false, "Java OOP" },
                    { "PRJ002", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(6971), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(6975), null, false, "Java Desktop" },
                    { "PRJ003", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7018), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7019), null, false, "Java Web" },
                    { "PRF001", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7021), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7022), null, false, "C" },
                    { "PRF002", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7024), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7025), null, false, "C++" },
                    { "PRF003", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7027), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7028), null, false, "C#" },
                    { "ENG001", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7029), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7031), null, false, "English 1" },
                    { "ENG002", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7032), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7033), null, false, "English 2" },
                    { "ENG003", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7035), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7036), null, false, "English 3" },
                    { "JPN001", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7038), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7039), null, false, "Japanese 1" },
                    { "JPN002", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7041), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7042), null, false, "Japanese 2" },
                    { "JPN003", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7099), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7101), null, false, "Japanese 3" },
                    { "CNN001", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7103), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7104), null, false, "Chinese 1" },
                    { "CNN002", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7105), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7107), null, false, "Chinese 2" },
                    { "CNN003", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7108), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7109), null, false, "Chinese 3" },
                    { "MKT001", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7111), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7112), null, false, "Marketing 1" },
                    { "MKT002", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7114), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7115), null, false, "Marketing 2" },
                    { "MKT003", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7117), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7118), null, false, "Marketing 3" },
                    { "GDS001", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7120), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7121), null, false, "History of Graphic Design" },
                    { "GDS002", new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7123), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(7124), null, false, "Design Basic" }
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
                columns: new[] { "Id", "About", "AvatarUrl", "Company", "IsGraduted", "MajorId", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219391"), null, null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219399"), null, null, null, false, "SB", 0, "3c5ec754-01b1-49cf-94e0-09250222b072" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219398"), null, null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b071" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), null, null, null, false, "SB", 0, "3c5ec754-01b1-49cf-94e0-09250222b071" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219396"), null, null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b070" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), null, null, null, false, "GD", 0, "3c5ec754-01b1-49cf-94e0-09250222b070" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), null, null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b069" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219393"), null, null, null, false, "GD", 0, "3c5ec754-01b1-49cf-94e0-09250222b069" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), null, null, null, false, "CN", 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), null, null, null, false, "CN", 0, "3c5ec754-01b1-49cf-94e0-09250222b072" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219390"), null, null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219388"), null, null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b065" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), null, null, null, false, "CN", 0, "3c5ec754-01b1-49cf-94e0-09250222b065" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219380"), null, null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b061" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), null, null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b062" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219382"), null, null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b062" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), null, null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b061" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219384"), null, null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b063" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219385"), null, null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b064" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219386"), null, null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b064" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219387"), null, null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b065" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), null, null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b063" }
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
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "ImageUrl", "IsDeleted", "MajorId", "MentorId", "Name", "Price", "Rating", "StartDate", "SubjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e336"), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(9236), new DateTime(2021, 10, 31, 10, 4, 44, 96, DateTimeKind.Local).AddTicks(9242), null, null, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 1", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ001", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e353"), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(69), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(70), null, null, false, "SB", new Guid("3f0c7479-25cd-4863-962e-a317ab219399"), "Course 18", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT003", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e352"), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(55), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(57), null, null, false, "SB", new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 17", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT002", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e351"), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(41), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(43), null, null, false, "SB", new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 16", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT001", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e356"), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(100), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(101), null, null, false, "GD", new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 21", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS003", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e355"), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(90), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(91), null, null, false, "GD", new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 20", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS002", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e344"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9896), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9897), null, null, false, "SA", new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), "Course 9", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG003", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e354"), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(79), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(81), null, null, false, "GD", new Guid("3f0c7479-25cd-4863-962e-a317ab219393"), "Course 19", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS001", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e349"), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(12), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(13), null, null, false, "CN", new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), "Course 14", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN002", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e347"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9928), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9929), null, null, false, "SJ", new Guid("3f0c7479-25cd-4863-962e-a317ab219391"), "Course 12", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN003", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e350"), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(27), new DateTime(2021, 10, 31, 10, 4, 44, 99, DateTimeKind.Local).AddTicks(29), null, null, false, "CN", new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), "Course 15", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN003", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e348"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9938), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9939), null, null, false, "CN", new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), "Course 13", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN001", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e346"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9918), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9919), null, null, false, "SJ", new Guid("3f0c7479-25cd-4863-962e-a317ab219388"), "Course 11", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN002", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e342"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9875), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9876), null, null, false, "SA", new Guid("3f0c7479-25cd-4863-962e-a317ab219387"), "Course 7", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG001", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e343"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9886), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9887), null, null, false, "SA", new Guid("3f0c7479-25cd-4863-962e-a317ab219390"), "Course 8", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG002", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e345"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9908), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9909), null, null, false, "SJ", new Guid("3f0c7479-25cd-4863-962e-a317ab219386"), "Course 10", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN001", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e339"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9841), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9842), null, null, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 4", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF001", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e341"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9864), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9865), null, null, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 6", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF003", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e338"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9824), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9826), null, null, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 3", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ003", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e337"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9702), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9710), null, null, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), "Course 2", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ002", null },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e340"), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9853), new DateTime(2021, 10, 31, 10, 4, 44, 98, DateTimeKind.Local).AddTicks(9854), null, null, false, "SE", new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), "Course 5", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF002", null }
                });

            migrationBuilder.InsertData(
                table: "SubjectMentors",
                columns: new[] { "Id", "MentorId", "Name", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("3f0c7479-25cd-4820-962e-a317ab219399"), new Guid("3f0c7479-25cd-4863-962e-a317ab219399"), "English 2", "ENG002" },
                    { new Guid("3f0c7479-25cd-4819-962e-a317ab219398"), new Guid("3f0c7479-25cd-4863-962e-a317ab219398"), "Marketing 1", "MKT001" },
                    { new Guid("3f0c7479-25cd-4818-962e-a317ab219397"), new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "English 1", "ENG001" },
                    { new Guid("3f0c7479-25cd-4800-962e-a317ab219379"), new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Java OOP", "PRJ001" },
                    { new Guid("3f0c7479-25cd-4801-962e-a317ab219380"), new Guid("3f0c7479-25cd-4863-962e-a317ab219380"), "English 1", "ENG001" },
                    { new Guid("3f0c7479-25cd-4817-962e-a317ab219396"), new Guid("3f0c7479-25cd-4863-962e-a317ab219396"), "English 3", "ENG003" },
                    { new Guid("3f0c7479-25cd-4816-962e-a317ab219395"), new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Design Basic", "GDS002" },
                    { new Guid("3f0c7479-25cd-4815-962e-a317ab219394"), new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), "English 2", "ENG002" },
                    { new Guid("3f0c7479-25cd-4814-962e-a317ab219393"), new Guid("3f0c7479-25cd-4863-962e-a317ab219393"), "History of Graphic Design", "GDS001" },
                    { new Guid("3f0c7479-25cd-4807-962e-a317ab219386"), new Guid("3f0c7479-25cd-4863-962e-a317ab219386"), "Japanese 2", "JPN002" },
                    { new Guid("3f0c7479-25cd-4803-962e-a317ab219382"), new Guid("3f0c7479-25cd-4863-962e-a317ab219382"), "English 2", "ENG002" },
                    { new Guid("3f0c7479-25cd-4813-962e-a317ab219392"), new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), "Chinese 2", "CNN002" },
                    { new Guid("3f0c7479-25cd-4812-962e-a317ab219391"), new Guid("3f0c7479-25cd-4863-962e-a317ab219391"), "Japanese 1", "JPN001" },
                    { new Guid("3f0c7479-25cd-4811-962e-a317ab219390"), new Guid("3f0c7479-25cd-4863-962e-a317ab219390"), "English 1", "ENG001" },
                    { new Guid("3f0c7479-25cd-4804-962e-a317ab219383"), new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Java Web", "PRJ003" },
                    { new Guid("3f0c7479-25cd-4810-962e-a317ab219389"), new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), "Chinese 1", "CNN001" },
                    { new Guid("3f0c7479-25cd-4805-962e-a317ab219384"), new Guid("3f0c7479-25cd-4863-962e-a317ab219384"), "Japanese 1", "JPN001" },
                    { new Guid("3f0c7479-25cd-4809-962e-a317ab219388"), new Guid("3f0c7479-25cd-4863-962e-a317ab219388"), "Japanese 3", "JPN003" },
                    { new Guid("3f0c7479-25cd-4806-962e-a317ab219385"), new Guid("3f0c7479-25cd-4863-962e-a317ab219385"), "Java OOP", "PRJ001" },
                    { new Guid("3f0c7479-25cd-4808-962e-a317ab219387"), new Guid("3f0c7479-25cd-4863-962e-a317ab219387"), "English 3", "ENG003" },
                    { new Guid("3f0c7479-25cd-4802-962e-a317ab219381"), new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), "Java Desktop", "PRJ002" },
                    { new Guid("3f0c7479-25cd-4821-962e-a317ab219400"), new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), "Marketing 2", "MKT002" }
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
                name: "IX_AspNetUsers_CourseId",
                table: "AspNetUsers",
                column: "CourseId");

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
                name: "IX_Course_UserId",
                table: "Course",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_UserId",
                table: "Course",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Mentor_MentorId",
                table: "Course",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_UserId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentor_AspNetUsers_UserId",
                table: "Mentor");

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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Mentor");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Major");
        }
    }
}
