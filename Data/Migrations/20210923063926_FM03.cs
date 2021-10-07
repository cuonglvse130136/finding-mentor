using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FM03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Majors_MajorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Mentor_MentorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Subjects_SubjectId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentor_Majors_MajorId",
                table: "Mentor");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Sections_SectionId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Student_StudentId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_SubjectMentors_SubjectMentorId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_Courses_CourseId",
                table: "StudentRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_Student_StudentId",
                table: "StudentRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMajors_Majors_MajorId",
                table: "SubjectMajors");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMajors_Subjects_SubjectId",
                table: "SubjectMajors");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMentors_AspNetUsers_MentorId",
                table: "SubjectMentors");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMentors_Subjects_SubjectId",
                table: "SubjectMentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectMentors",
                table: "SubjectMentors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectMajors",
                table: "SubjectMajors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRegistrations",
                table: "StudentRegistrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Majors",
                table: "Majors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "SubjectMentors",
                newName: "SubjectMentor");

            migrationBuilder.RenameTable(
                name: "SubjectMajors",
                newName: "SubjectMajor");

            migrationBuilder.RenameTable(
                name: "StudentRegistrations",
                newName: "StudentRegistration");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "Section");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "Resource");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Majors",
                newName: "Major");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_UserId",
                table: "Transaction",
                newName: "IX_Transaction_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectMentors_SubjectId",
                table: "SubjectMentor",
                newName: "IX_SubjectMentor_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectMentors_MentorId",
                table: "SubjectMentor",
                newName: "IX_SubjectMentor_MentorId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectMajors_SubjectId",
                table: "SubjectMajor",
                newName: "IX_SubjectMajor_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRegistrations_StudentId",
                table: "StudentRegistration",
                newName: "IX_StudentRegistration_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRegistrations_CourseId",
                table: "StudentRegistration",
                newName: "IX_StudentRegistration_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_CourseId",
                table: "Section",
                newName: "IX_Section_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_SubjectMentorId",
                table: "Resource",
                newName: "IX_Resource_SubjectMentorId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_StudentId",
                table: "Question",
                newName: "IX_Question_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_SectionId",
                table: "Question",
                newName: "IX_Question_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_SubjectId",
                table: "Course",
                newName: "IX_Course_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_MentorId",
                table: "Course",
                newName: "IX_Course_MentorId");

            migrationBuilder.AlterColumn<string>(
                name: "MajorId",
                table: "Mentor",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MajorId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "SubjectMentor",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "SubjectMajor",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "MajorId",
                table: "SubjectMajor",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Major",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "Course",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectMentor",
                table: "SubjectMentor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectMajor",
                table: "SubjectMajor",
                columns: new[] { "MajorId", "SubjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRegistration",
                table: "StudentRegistration",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section",
                table: "Section",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                table: "Resource",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Major",
                table: "Major",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Major_MajorId",
                table: "AspNetUsers",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Mentor_MentorId",
                table: "Course",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subject_SubjectId",
                table: "Course",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentor_Major_MajorId",
                table: "Mentor",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Section_SectionId",
                table: "Question",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Student_StudentId",
                table: "Question",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_SubjectMentor_SubjectMentorId",
                table: "Resource",
                column: "SubjectMentorId",
                principalTable: "SubjectMentor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Course_CourseId",
                table: "Section",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistration_Course_CourseId",
                table: "StudentRegistration",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistration_Student_StudentId",
                table: "StudentRegistration",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMajor_Major_MajorId",
                table: "SubjectMajor",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMajor_Subject_SubjectId",
                table: "SubjectMajor",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMentor_AspNetUsers_MentorId",
                table: "SubjectMentor",
                column: "MentorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMentor_Subject_SubjectId",
                table: "SubjectMentor",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Major_MajorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Mentor_MentorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_SubjectId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentor_Major_MajorId",
                table: "Mentor");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Section_SectionId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Student_StudentId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_SubjectMentor_SubjectMentorId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Course_CourseId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistration_Course_CourseId",
                table: "StudentRegistration");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistration_Student_StudentId",
                table: "StudentRegistration");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMajor_Major_MajorId",
                table: "SubjectMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMajor_Subject_SubjectId",
                table: "SubjectMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMentor_AspNetUsers_MentorId",
                table: "SubjectMentor");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMentor_Subject_SubjectId",
                table: "SubjectMentor");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectMentor",
                table: "SubjectMentor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectMajor",
                table: "SubjectMajor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRegistration",
                table: "StudentRegistration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                table: "Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Major",
                table: "Major");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "SubjectMentor",
                newName: "SubjectMentors");

            migrationBuilder.RenameTable(
                name: "SubjectMajor",
                newName: "SubjectMajors");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "StudentRegistration",
                newName: "StudentRegistrations");

            migrationBuilder.RenameTable(
                name: "Section",
                newName: "Sections");

            migrationBuilder.RenameTable(
                name: "Resource",
                newName: "Resources");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Major",
                newName: "Majors");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_UserId",
                table: "Transactions",
                newName: "IX_Transactions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectMentor_SubjectId",
                table: "SubjectMentors",
                newName: "IX_SubjectMentors_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectMentor_MentorId",
                table: "SubjectMentors",
                newName: "IX_SubjectMentors_MentorId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectMajor_SubjectId",
                table: "SubjectMajors",
                newName: "IX_SubjectMajors_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRegistration_StudentId",
                table: "StudentRegistrations",
                newName: "IX_StudentRegistrations_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRegistration_CourseId",
                table: "StudentRegistrations",
                newName: "IX_StudentRegistrations_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_CourseId",
                table: "Sections",
                newName: "IX_Sections_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_SubjectMentorId",
                table: "Resources",
                newName: "IX_Resources_SubjectMentorId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_StudentId",
                table: "Questions",
                newName: "IX_Questions_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_SectionId",
                table: "Questions",
                newName: "IX_Questions_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_SubjectId",
                table: "Courses",
                newName: "IX_Courses_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_MentorId",
                table: "Courses",
                newName: "IX_Courses_MentorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "MajorId",
                table: "Mentor",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MajorId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "SubjectMentors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "SubjectMajors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "MajorId",
                table: "SubjectMajors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Majors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectMentors",
                table: "SubjectMentors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectMajors",
                table: "SubjectMajors",
                columns: new[] { "MajorId", "SubjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRegistrations",
                table: "StudentRegistrations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Majors",
                table: "Majors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Majors_MajorId",
                table: "AspNetUsers",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Mentor_MentorId",
                table: "Courses",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Subjects_SubjectId",
                table: "Courses",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentor_Majors_MajorId",
                table: "Mentor",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Sections_SectionId",
                table: "Questions",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Student_StudentId",
                table: "Questions",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_SubjectMentors_SubjectMentorId",
                table: "Resources",
                column: "SubjectMentorId",
                principalTable: "SubjectMentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_Courses_CourseId",
                table: "StudentRegistrations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_Student_StudentId",
                table: "StudentRegistrations",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMajors_Majors_MajorId",
                table: "SubjectMajors",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMajors_Subjects_SubjectId",
                table: "SubjectMajors",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMentors_AspNetUsers_MentorId",
                table: "SubjectMentors",
                column: "MentorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMentors_Subjects_SubjectId",
                table: "SubjectMentors",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
