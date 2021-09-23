using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FM02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Mentor_MentorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentor_AspNetUsers_UserId1",
                table: "Mentor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor");

            migrationBuilder.DropIndex(
                name: "IX_Mentor_UserId1",
                table: "Mentor");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Mentor");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Mentor",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Mentor",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mentor_UserId",
                table: "Mentor",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Mentor_MentorId",
                table: "Courses",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentor_AspNetUsers_UserId",
                table: "Mentor",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Mentor_MentorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentor_AspNetUsers_UserId",
                table: "Mentor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor");

            migrationBuilder.DropIndex(
                name: "IX_Mentor_UserId",
                table: "Mentor");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mentor");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Mentor",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Mentor",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentor_UserId1",
                table: "Mentor",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Mentor_MentorId",
                table: "Courses",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentor_AspNetUsers_UserId1",
                table: "Mentor",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
