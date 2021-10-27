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
                    { "3c5ec754-01b1-49cf-94e0-09250222b060", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e9041923-1f99-41f7-9f46-58fa2127116f", null, false, "Admin Ne`", null, false, false, false, null, null, null, "admin", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "e86e9a06-9f90-4213-9065-53345b66df02", false, "admin" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b062", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fa771d18-863d-458a-be15-2480c0f2972c", null, false, "Mr. Emp2", null, false, false, false, null, null, null, "emp2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "0485ba68-a9f6-4e8a-9cea-c47f3ef724fd", false, "emp2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b063", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b626fb86-aaf0-4333-a165-8d8d61275dbb", null, false, "Mr. Emp3", null, false, false, false, null, null, null, "emp3", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "8ccfc18d-fdd7-4d9b-a218-3c1a58cc8ca5", false, "emp3" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b064", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f587198b-73cc-4478-b379-e81b81c65d6e", null, false, "Mr. Emp4", null, false, false, false, null, null, null, "emp4", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "69442a0e-e3a6-45fc-a79f-08559e4fd8b6", false, "emp4" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b065", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cebf6cf7-3d22-42df-80b0-43dc626a9898", null, false, "Mr. Emp5", null, false, false, false, null, null, null, "emp5", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "21bab382-0e1d-4957-8888-2f523c559c30", false, "emp5" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b066", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "556f6ab1-cc79-47f6-87e5-a36b927f9b14", null, false, "Mr. Loc", null, false, false, false, null, null, null, "loc", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "427ca7d4-15c9-4aec-9516-e6b2426df539", false, "loc" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b067", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7bf3f899-4f84-4765-83e4-155009152a78", null, false, "Mr. Tam", null, false, false, false, null, null, null, "tam", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "669014e9-c9e6-41e8-8f89-aefd9c82254b", false, "tam" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b068", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "90367c15-b6a5-4545-bde9-dfa118cb7752", null, false, "Mr. Emp6", null, false, false, false, null, null, null, "emp6", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "7406cd4e-95bf-4178-aa79-eb9217206719", false, "emp6" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b069", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ea2c0ab9-88cf-41c8-b14c-c4fea2bda5d8", null, false, "Mr. Emp7", null, false, false, false, null, null, null, "emp7", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "1ca768e4-09b2-4ddf-adf1-05c9b7c12e86", false, "emp7" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b070", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dbf50caa-b9cf-4a20-8e5b-bd1b9056dce9", null, false, "Mr. Emp8", null, false, false, false, null, null, null, "emp8", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "f652b253-a1e0-42f9-af88-e19ca372375e", false, "emp8" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b071", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3e96f78e-e21e-425f-b8e5-8820d2249371", null, false, "Mr. Emp9", null, false, false, false, null, null, null, "emp9", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "2413dfb7-7697-4cc3-b405-e6ec99db33fa", false, "emp9" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b073", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "98d00cf2-69ef-4f65-974d-2679ec8c882e", null, false, "Mr. Loc1", null, false, false, false, null, null, null, "loc1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "215796f7-e827-4fba-bb58-bb5ee99a34f3", false, "loc1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b074", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1ef43cf4-5eae-47ef-8265-b26a4974a443", null, false, "Mr. Tam1", null, false, false, false, null, null, null, "tam1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "3e71f002-7c56-4916-9ee4-3e0b62fb72ec", false, "tam1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b075", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "77a38657-a6bf-4051-8a48-00d08fa67d41", null, false, "Mr. Emp11", null, false, false, false, null, null, null, "emp11", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "82a40a4d-d517-4052-b6ce-9ec52a2b6f96", false, "emp11" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b076", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4f231135-db25-4dd7-84ea-489b17932ba7", null, false, "Mr. Emp12", null, false, false, false, null, null, null, "emp12", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "76cab629-73cf-4c0a-8612-aa88d4082f53", false, "emp12" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b077", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9099fe29-0d38-4722-b1f3-49578359bf34", null, false, "Mr. Emp13", null, false, false, false, null, null, null, "emp13", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "481bb453-4bbd-4e6a-824a-79c3bff11de1", false, "emp13" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b078", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9e261016-b735-456f-8c3d-7107bbe8a4f9", null, false, "Mr. Emp14", null, false, false, false, null, null, null, "emp14", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "de32cd51-9534-42c3-8f30-5b6bdd92d8d2", false, "emp14" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b079", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6322e9ac-845f-4b4d-9556-eac827bb1b1a", null, false, "Mr. Emp15", null, false, false, false, null, null, null, "emp15", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "13b62ea3-518a-4fb1-b03f-7753b617d1b7", false, "emp15" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b080", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d6a7ddc5-af40-4088-9036-f53e3bf8fbd1", null, false, "Mr. Loc2", null, false, false, false, null, null, null, "loc2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "1b4c2e93-9e93-455c-92ac-0efee681f9d8", false, "loc2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b081", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8fcc3e38-0284-4a2b-b93a-d4889808725f", null, false, "Mr. Tam2", null, false, false, false, null, null, null, "tam2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "d030e831-c950-4d6a-83b7-ca43710f002c", false, "tam2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b061", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "83e0196a-4ac9-45ce-98a1-adc93031bc94", null, false, "Mr. Emp1", null, false, false, false, null, null, null, "emp1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "6e41a5ff-92a3-46b5-a0c1-c67666322576", false, "emp1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b072", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dcbe34c3-8853-4e42-8aaf-e88fcfce068d", null, false, "Mr. Emp10", null, false, false, false, null, null, null, "emp10", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "ac47003d-134c-4442-8dc3-2a67c5425a7b", false, "emp10" }
                });

            migrationBuilder.InsertData(
                table: "Major",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "SE", new DateTime(2021, 10, 27, 22, 30, 14, 679, DateTimeKind.Local).AddTicks(1743), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(680), null, false, "Software Engineering" },
                    { "SB", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1402), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1408), null, false, "Economic" },
                    { "SA", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1423), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1425), null, false, "English" },
                    { "CN", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1427), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1428), null, false, "Chinese" },
                    { "SJ", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1429), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1430), null, false, "Japanese" },
                    { "GD", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1432), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(1433), null, false, "Graphic Design" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "GDS003", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5641), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5642), null, false, "Design Advance" },
                    { "PRJ001", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5006), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5014), null, false, "Java OOP" },
                    { "PRJ002", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5560), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5563), null, false, "Java Desktop" },
                    { "PRJ003", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5590), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5592), null, false, "Java Web" },
                    { "PRF001", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5594), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5595), null, false, "C" },
                    { "PRF002", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5596), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5597), null, false, "C++" },
                    { "PRF003", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5599), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5600), null, false, "C#" },
                    { "ENG001", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5602), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5603), null, false, "English 1" },
                    { "ENG002", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5605), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5606), null, false, "English 2" },
                    { "ENG003", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5607), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5608), null, false, "English 3" },
                    { "JPN001", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5610), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5611), null, false, "Japanese 1" },
                    { "JPN002", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5613), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5614), null, false, "Japanese 2" },
                    { "JPN003", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5616), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5617), null, false, "Japanese 3" },
                    { "CNN001", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5619), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5620), null, false, "Chinese 1" },
                    { "CNN002", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5621), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5623), null, false, "Chinese 2" },
                    { "CNN003", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5624), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5625), null, false, "Chinese 3" },
                    { "MKT001", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5627), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5628), null, false, "Marketing 1" },
                    { "MKT002", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5630), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5631), null, false, "Marketing 2" },
                    { "MKT003", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5633), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5634), null, false, "Marketing 3" },
                    { "GDS001", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5635), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5637), null, false, "History of Graphic Design" },
                    { "GDS002", new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5638), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(5639), null, false, "Design Basic" }
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
                    { "3c5ec754-01b1-49cf-94e0-09250222b070", "MENTOR" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b071", "MENTOR" },
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
                columns: new[] { "Id", "About", "Company", "IsGraduted", "MajorId", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), null, null, false, "CN", 0, "3c5ec754-01b1-49cf-94e0-09250222b072" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219399"), null, null, false, "SB", 0, "3c5ec754-01b1-49cf-94e0-09250222b072" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), null, null, false, "SB", 0, "3c5ec754-01b1-49cf-94e0-09250222b071" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b061" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219380"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b061" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b062" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219382"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b062" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b063" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219384"), null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b063" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219385"), null, null, false, "SE", 0, "3c5ec754-01b1-49cf-94e0-09250222b064" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219398"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b071" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219387"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b065" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219386"), null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b064" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), null, null, false, "CN", 0, "3c5ec754-01b1-49cf-94e0-09250222b065" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219390"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219391"), null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), null, null, false, "CN", 0, "3c5ec754-01b1-49cf-94e0-09250222b068" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219393"), null, null, false, "GD", 0, "3c5ec754-01b1-49cf-94e0-09250222b069" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b069" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), null, null, false, "GD", 0, "3c5ec754-01b1-49cf-94e0-09250222b070" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219396"), null, null, false, "SA", 0, "3c5ec754-01b1-49cf-94e0-09250222b070" },
                    { new Guid("3f0c7479-25cd-4863-962e-a317ab219388"), null, null, false, "SJ", 0, "3c5ec754-01b1-49cf-94e0-09250222b065" }
                });

            migrationBuilder.InsertData(
                table: "SubjectMajor",
                columns: new[] { "MajorId", "SubjectId" },
                values: new object[,]
                {
                    { "SE", "PRJ003" },
                    { "SE", "PRJ002" },
                    { "SE", "PRJ001" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "MentorId", "Name", "Price", "Rating", "StartDate", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e336"), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(7705), new DateTime(2021, 10, 27, 22, 30, 14, 680, DateTimeKind.Local).AddTicks(7712), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 1", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e352"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7689), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7691), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 17", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e351"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7679), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7681), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 16", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e356"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7730), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7732), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 21", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e355"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7720), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7721), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 20", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e344"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7607), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7608), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), "Course 9", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e354"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7710), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7711), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219393"), "Course 19", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e349"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7659), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7660), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), "Course 14", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e347"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7638), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7639), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219391"), "Course 12", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e353"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7700), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7701), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219399"), "Course 18", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e343"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7596), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7597), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219390"), "Course 8", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e346"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7628), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7629), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219388"), "Course 11", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e342"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7585), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7587), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219387"), "Course 7", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e345"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7618), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7619), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219386"), "Course 10", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e341"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7575), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7576), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 6", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e338"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7534), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7536), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 3", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e340"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7563), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7564), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), "Course 5", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e337"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7424), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7432), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), "Course 2", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e339"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7550), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7551), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 4", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e348"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7648), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7649), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), "Course 13", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e350"), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7669), new DateTime(2021, 10, 27, 22, 30, 14, 682, DateTimeKind.Local).AddTicks(7670), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), "Course 15", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN003" }
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
