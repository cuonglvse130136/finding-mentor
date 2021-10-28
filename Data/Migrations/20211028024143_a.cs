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
                    { "3c5ec754-01b1-49cf-94e0-09250222b060", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "865ab79a-edc8-4d0a-a0a9-3da734807cf0", null, false, "Admin Ne`", null, false, false, false, null, null, null, "admin", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "a3c402b3-6ee8-4966-9240-8d655058c636", false, "admin" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b062", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "771f9ee4-9829-486d-872d-d4f5bd834032", null, false, "Mr. Emp2", null, false, false, false, null, null, null, "emp2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "1ecf8520-a21d-45b3-a952-a164e6d3f133", false, "emp2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b063", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "409a6079-f93e-4d86-bf8e-2f0562797dbb", null, false, "Mr. Emp3", null, false, false, false, null, null, null, "emp3", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "26f4d385-be73-4bc5-aef1-cdc3ca7674df", false, "emp3" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b064", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f08c6418-1d64-48ae-8a87-fd47bed34929", null, false, "Mr. Emp4", null, false, false, false, null, null, null, "emp4", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "9b3085e7-22f3-42e1-8b17-9f9a855f8e51", false, "emp4" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b065", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1a774a46-b14d-4d34-a9f8-54fb5bde16fb", null, false, "Mr. Emp5", null, false, false, false, null, null, null, "emp5", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "c6ef75a6-d74a-4d4b-a457-7a705f3b9d01", false, "emp5" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b066", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "55be1223-2a4a-4eb7-a759-1c90e04f30b5", null, false, "Mr. Loc", null, false, false, false, null, null, null, "loc", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "23153b3a-7b93-434b-a919-75f49458ede2", false, "loc" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b067", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "55a56b22-30da-4618-a740-e10dbfe54729", null, false, "Mr. Tam", null, false, false, false, null, null, null, "tam", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "72143818-2531-4075-9263-c29ac679f989", false, "tam" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b068", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e75531bc-e93d-4d8c-b5f7-d6db1535ed92", null, false, "Mr. Emp6", null, false, false, false, null, null, null, "emp6", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "5f6adeb9-69e3-43df-871a-df894cb36cf9", false, "emp6" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b069", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03bc568b-3f36-46a0-8916-3616865dc216", null, false, "Mr. Emp7", null, false, false, false, null, null, null, "emp7", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "30c15a14-0c69-490c-9803-7a7abea1b177", false, "emp7" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b070", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0043b57b-e1e3-43c2-8c1d-b3ee62aa39a4", null, false, "Mr. Emp8", null, false, false, false, null, null, null, "emp8", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "5136e5cc-7deb-443e-ba8e-a83ccd330066", false, "emp8" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b071", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ad7d870e-3838-46a1-9a62-f81fd19b734e", null, false, "Mr. Emp9", null, false, false, false, null, null, null, "emp9", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "e30d7af4-551c-4f27-99e1-7c3698a5d1e8", false, "emp9" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b073", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "422701cd-3347-4b53-a62a-17759a9bc5e5", null, false, "Mr. Loc1", null, false, false, false, null, null, null, "loc1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "7e7ab28c-fb3c-4b00-ae04-128692f01127", false, "loc1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b074", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0eb3b26b-0686-47ac-8a1e-b1958b12d4e1", null, false, "Mr. Tam1", null, false, false, false, null, null, null, "tam1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "767537f4-8603-42dc-ba3c-1b28c2ef0149", false, "tam1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b075", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bb6bff6a-31df-4846-9894-7d85bd55028c", null, false, "Mr. Emp11", null, false, false, false, null, null, null, "emp11", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "e2e3c85a-ab81-47a8-8fd8-8f9ca49debde", false, "emp11" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b076", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4067f8e9-798c-486b-a0d1-3e7484ff5484", null, false, "Mr. Emp12", null, false, false, false, null, null, null, "emp12", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "a0789922-4101-480d-9394-128712e92bf9", false, "emp12" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b077", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "73040d64-15a0-4251-9dd6-3fc874fac4af", null, false, "Mr. Emp13", null, false, false, false, null, null, null, "emp13", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "a93ea445-8e13-4530-9ebd-1c03fcda2e07", false, "emp13" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b078", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c03bab15-2c84-4bda-81c4-55e156adf32d", null, false, "Mr. Emp14", null, false, false, false, null, null, null, "emp14", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "0cf314cd-2052-4a4a-9975-04055bcf5778", false, "emp14" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b079", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "472aa753-653f-467c-8abc-e56c133baf89", null, false, "Mr. Emp15", null, false, false, false, null, null, null, "emp15", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "7e76ae8e-f6b0-41ff-8ebc-72d5ba0c841c", false, "emp15" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b080", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "22627616-56e6-4b28-ba8d-8d39b8a0c655", null, false, "Mr. Loc2", null, false, false, false, null, null, null, "loc2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "ce7a000e-0496-405e-886a-2c0bd4103c39", false, "loc2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b081", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fc4d1fb3-390d-4c0d-9ec9-78075bf18ebd", null, false, "Mr. Tam2", null, false, false, false, null, null, null, "tam2", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "0b8af151-5e57-474a-961e-7dfcd652af36", false, "tam2" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b061", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6c0e9948-3972-4892-9898-5e759f377e82", null, false, "Mr. Emp1", null, false, false, false, null, null, null, "emp1", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "37e0073f-37d6-4510-9f8f-3834dbd90c08", false, "emp1" },
                    { "3c5ec754-01b1-49cf-94e0-09250222b072", 0, null, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "88673459-e371-42ae-ac2e-12cd24fd4850", null, false, "Mr. Emp10", null, false, false, false, null, null, null, "emp10", "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", null, false, "4622bfb9-40ad-42c2-9604-fbbbb59c4917", false, "emp10" }
                });

            migrationBuilder.InsertData(
                table: "Major",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "SE", new DateTime(2021, 10, 28, 9, 41, 42, 389, DateTimeKind.Local).AddTicks(3978), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(2743), null, false, "Software Engineering" },
                    { "SB", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3506), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3510), null, false, "Economic" },
                    { "SA", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3525), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3527), null, false, "English" },
                    { "CN", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3528), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3529), null, false, "Chinese" },
                    { "SJ", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3531), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3532), null, false, "Japanese" },
                    { "GD", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3580), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(3582), null, false, "Graphic Design" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "GDS003", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9803), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9804), null, false, "Design Advance" },
                    { "PRJ001", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9159), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9165), null, false, "Java OOP" },
                    { "PRJ002", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9733), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9736), null, false, "Java Desktop" },
                    { "PRJ003", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9753), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9754), null, false, "Java Web" },
                    { "PRF001", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9756), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9757), null, false, "C" },
                    { "PRF002", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9759), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9760), null, false, "C++" },
                    { "PRF003", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9762), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9763), null, false, "C#" },
                    { "ENG001", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9765), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9766), null, false, "English 1" },
                    { "ENG002", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9768), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9769), null, false, "English 2" },
                    { "ENG003", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9770), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9771), null, false, "English 3" },
                    { "JPN001", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9773), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9774), null, false, "Japanese 1" },
                    { "JPN002", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9776), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9777), null, false, "Japanese 2" },
                    { "JPN003", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9778), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9779), null, false, "Japanese 3" },
                    { "CNN001", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9781), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9782), null, false, "Chinese 1" },
                    { "CNN002", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9784), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9785), null, false, "Chinese 2" },
                    { "CNN003", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9787), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9788), null, false, "Chinese 3" },
                    { "MKT001", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9790), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9791), null, false, "Marketing 1" },
                    { "MKT002", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9792), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9793), null, false, "Marketing 2" },
                    { "MKT003", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9795), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9796), null, false, "Marketing 3" },
                    { "GDS001", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9798), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9799), null, false, "History of Graphic Design" },
                    { "GDS002", new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9800), new DateTime(2021, 10, 28, 9, 41, 42, 390, DateTimeKind.Local).AddTicks(9801), null, false, "Design Basic" }
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
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e336"), new DateTime(2021, 10, 28, 9, 41, 42, 391, DateTimeKind.Local).AddTicks(1943), new DateTime(2021, 10, 28, 9, 41, 42, 391, DateTimeKind.Local).AddTicks(1949), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 1", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e353"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5333), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5335), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219399"), "Course 18", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e352"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5323), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5324), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 17", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e351"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5312), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5313), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219397"), "Course 16", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKT001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e356"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5364), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5365), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 21", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e355"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5354), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5355), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219395"), "Course 20", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e344"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5237), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5238), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219394"), "Course 9", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e354"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5344), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5345), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219393"), "Course 19", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "GDS001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e349"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5291), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5292), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219392"), "Course 14", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e347"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5270), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5271), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219391"), "Course 12", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e350"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5302), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5303), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219400"), "Course 15", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e348"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5280), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5281), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219389"), "Course 13", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNN001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e346"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5259), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5260), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219388"), "Course 11", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e342"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5214), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5215), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219387"), "Course 7", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e343"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5227), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5228), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219390"), "Course 8", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e345"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5248), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5250), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219386"), "Course 10", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPN001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e339"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5080), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5081), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219379"), "Course 4", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF001" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e341"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5201), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5202), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 6", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e338"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5064), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5065), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219383"), "Course 3", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ003" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e337"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(4934), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(4955), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), "Course 2", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ002" },
                    { new Guid("1d6940a7-7035-4bc0-baa4-06174e05e340"), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5095), new DateTime(2021, 10, 28, 9, 41, 42, 393, DateTimeKind.Local).AddTicks(5096), null, false, new Guid("3f0c7479-25cd-4863-962e-a317ab219381"), "Course 5", 100.0, 0, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF002" }
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
