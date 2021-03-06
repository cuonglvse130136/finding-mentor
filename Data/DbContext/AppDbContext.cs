using Data.Entities;
using Data.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DbContext
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region Entities

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectMajor> SubjectMajors { get; set; }
        public virtual DbSet<AvailableMajor> AvailableMajors { get; set; }
        public virtual DbSet<SubjectMentor> SubjectMentors { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> User { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seed User data
            modelBuilder.Entity<User>().HasData(
                //new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b060", UserName = "admin", NormalizedUserName = "admin", Fullname = "Administrator", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==" },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b061", UserName = "DjBeLLGyjwceuwuXecHNSl74XG12", NormalizedUserName = "DjBeLLGyjwceuwuXecHNSl74XG12", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Cuong Ly", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b062", UserName = "emp2", NormalizedUserName = "emp2", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp2", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b063", UserName = "emp3", NormalizedUserName = "emp3", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp3", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b064", UserName = "emp4", NormalizedUserName = "emp4", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp4", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b065", UserName = "emp5", NormalizedUserName = "emp5", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp5", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b066", UserName = "loc", NormalizedUserName = "loc", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Loc", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b067", UserName = "tam", NormalizedUserName = "tam", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Tam", },

                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b068", UserName = "emp6", NormalizedUserName = "emp6", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp6", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b069", UserName = "emp7", NormalizedUserName = "emp7", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp7", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b070", UserName = "emp8", NormalizedUserName = "emp8", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp8", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b071", UserName = "emp9", NormalizedUserName = "emp9", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp9", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b072", UserName = "emp10", NormalizedUserName = "emp10", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp10", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b073", UserName = "loc1", NormalizedUserName = "loc1", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Loc1", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b074", UserName = "tam1", NormalizedUserName = "tam1", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Tam1", },

                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b075", UserName = "emp11", NormalizedUserName = "emp11", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp11", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b076", UserName = "emp12", NormalizedUserName = "emp12", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp12", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b077", UserName = "emp13", NormalizedUserName = "emp13", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp13", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b078", UserName = "emp14", NormalizedUserName = "emp14", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp14", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b079", UserName = "emp15", NormalizedUserName = "emp15", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Emp15", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b080", UserName = "loc2", NormalizedUserName = "loc2", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Mr. Loc2", },
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b081", UserName = "NDuV7ocmAIUbXMaCyMdG1pmC0yJ2", NormalizedUserName = "NDuV7ocmAIUbXMaCyMdG1pmC0yJ2", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==", Fullname = "Tam Nguyen",MajorId ="SE" }

            );
            #endregion

            #region Seed Major data
            modelBuilder.Entity<Major>().HasData(
                new Major() { Id = "SE", Name = "Software Engineering" },
                new Major() { Id = "SB", Name = "Economic" },
                new Major() { Id = "SA", Name = "English" },
                new Major() { Id = "CN", Name = "Chinese" },
                new Major() { Id = "SJ", Name = "Japanese" },
                new Major() { Id = "GD", Name = "Graphic Design" }
            );
            #endregion

            #region Seed Mentor data

            modelBuilder.Entity<Mentor>().HasData(
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219379"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b061" },
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219382"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b062" },
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219383"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b063" },
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219385"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b064" },
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219389"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b065" },
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219392"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b068" },
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219394"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b069" },
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219395"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b070" },
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219397"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b071" },
                new Mentor() { Id = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219400"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b072" }
            );
            #endregion
            #region Seed AvailableMajor data
            modelBuilder.Entity<AvailableMajor>().HasData(
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219379"), MajorId = "SE" },
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219382"), MajorId = "SE" },
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219383"), MajorId = "SE" },
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219385"), MajorId = "SE" },
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219389"), MajorId = "SE" },
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219392"), MajorId = "SE" },
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219394"), MajorId = "SE" },
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219395"), MajorId = "SE" },
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219397"), MajorId = "SE" },
                new AvailableMajor() { MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219400"), MajorId = "SE" }
                );
            #endregion
            #region Seed SubjectMentor data
            modelBuilder.Entity<SubjectMentor>().HasData(
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4800-962e-a317ab219379"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219379"), SubjectId = "PRJ001", Name = "Java OOP" },
                
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4803-962e-a317ab219382"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219382"), SubjectId = "PRJ003", Name = "English 2" },
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4804-962e-a317ab219383"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219383"), SubjectId = "PRJ003", Name = "Java Web" },
                
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4806-962e-a317ab219385"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219385"), SubjectId = "PRJ001", Name = "Java OOP" },
               
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4810-962e-a317ab219389"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219389"), SubjectId = "PRJ003", Name = "Chinese 1" },
            
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4813-962e-a317ab219392"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219392"), SubjectId = "PRJ003", Name = "Chinese 2" },
              
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4815-962e-a317ab219394"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219394"), SubjectId = "PRJ003", Name = "English 2" },
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4816-962e-a317ab219395"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219395"), SubjectId = "PRJ003", Name = "Design Basic" },
              
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4818-962e-a317ab219397"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219397"), SubjectId = "PRJ003", Name = "English 1" },
              
                new SubjectMentor() { Id = Guid.Parse("3f0c7479-25cd-4821-962e-a317ab219400"), MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219400"), SubjectId = "PRJ003", Name = "Marketing 2" }
            );
            #endregion

            #region Seed Subject data
            modelBuilder.Entity<Subject>().HasData(
                new Subject() { Id = "PRJ001", Name = "Java OOP" },
                new Subject() { Id = "PRJ002", Name = "Java Desktop" },
                new Subject() { Id = "PRJ003", Name = "Java Web" },
                new Subject() { Id = "PRF001", Name = "C" },
                new Subject() { Id = "PRF002", Name = "C++" },
                new Subject() { Id = "PRF003", Name = "C#" },
                new Subject() { Id = "ENG001", Name = "English 1" },
                new Subject() { Id = "ENG002", Name = "English 2" },
                new Subject() { Id = "ENG003", Name = "English 3" },
                new Subject() { Id = "JPN001", Name = "Japanese 1" },
                new Subject() { Id = "JPN002", Name = "Japanese 2" },
                new Subject() { Id = "JPN003", Name = "Japanese 3" },
                new Subject() { Id = "CNN001", Name = "Chinese 1" },
                new Subject() { Id = "CNN002", Name = "Chinese 2" },
                new Subject() { Id = "CNN003", Name = "Chinese 3" },
                new Subject() { Id = "MKT001", Name = "Marketing 1" },
                new Subject() { Id = "MKT002", Name = "Marketing 2" },
                new Subject() { Id = "MKT003", Name = "Marketing 3" },
                new Subject() { Id = "GDS001", Name = "History of Graphic Design" },
                new Subject() { Id = "GDS002", Name = "Design Basic" },
                new Subject() { Id = "GDS003", Name = "Design Advance" }
            );

            modelBuilder.Entity<SubjectMajor>().HasData(
                    new SubjectMajor() { MajorId = "SE", SubjectId = "PRJ001" },
                    new SubjectMajor() { MajorId = "SE", SubjectId = "PRJ002" },
                    new SubjectMajor() { MajorId = "SE", SubjectId = "PRJ003" },
                    new SubjectMajor() { MajorId = "SE", SubjectId = "PRF001" },
                    new SubjectMajor() { MajorId = "SE", SubjectId = "PRF002" },
                    new SubjectMajor() { MajorId = "SE", SubjectId = "PRF003" },
                    new SubjectMajor() { MajorId = "SA", SubjectId = "ENG001" },
                    new SubjectMajor() { MajorId = "SA", SubjectId = "ENG002" },
                    new SubjectMajor() { MajorId = "SA", SubjectId = "ENG003" },
                    new SubjectMajor() { MajorId = "SJ", SubjectId = "JPN001" },
                    new SubjectMajor() { MajorId = "SJ", SubjectId = "JPN002" },
                    new SubjectMajor() { MajorId = "SJ", SubjectId = "JPN003" },
                    new SubjectMajor() { MajorId = "CN", SubjectId = "CNN001" },
                    new SubjectMajor() { MajorId = "CN", SubjectId = "CNN002" },
                    new SubjectMajor() { MajorId = "CN", SubjectId = "CNN003" },
                    new SubjectMajor() { MajorId = "SB", SubjectId = "MKT001" },
                    new SubjectMajor() { MajorId = "SB", SubjectId = "MKT002" },
                    new SubjectMajor() { MajorId = "SB", SubjectId = "MKT003" },
                    new SubjectMajor() { MajorId = "GD", SubjectId = "GDS001" },
                    new SubjectMajor() { MajorId = "GD", SubjectId = "GDS002" },
                    new SubjectMajor() { MajorId = "GD", SubjectId = "GDS003" }
            );

            //many course
            //new Subject() { Id = "HCM001", Name = "Ho Chi Minh History" },
            //new Subject() { Id = "VNR001", Name = "Vietnam Road" },
            //new Subject() { Id = "SYB001", Name = "Start up your Business" },
            //new Subject() { Id = "SSG001", Name = "Working in Group Skill" },
            //new Subject() { Id = "SSC001", Name = "Community Skill" },
            #endregion

            #region Seed Course data
            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e336"), Name = "Course 1", SubjectId = "PRJ001", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219379"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "SE",Description = "ABC FCK", Duration="2 week" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e338"), Name = "Course 3", SubjectId = "PRJ003", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219383"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "SE" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e339"), Name = "Course 4", SubjectId = "PRF001", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219379"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "SE" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e341"), Name = "Course 6", SubjectId = "PRF003", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219383"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "SE" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e344"), Name = "Course 9", SubjectId = "ENG003", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219394"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "SA" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e348"), Name = "Course 13", SubjectId = "CNN001", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219389"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "CN" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e349"), Name = "Course 14", SubjectId = "CNN002", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219392"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "CN" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e350"), Name = "Course 15", SubjectId = "CNN003", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219400"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "CN" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e351"), Name = "Course 16", SubjectId = "MKT001", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219397"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "SB" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e352"), Name = "Course 17", SubjectId = "MKT002", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219397"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "SB" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e355"), Name = "Course 20", SubjectId = "GDS002", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219395"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "GD" },
                new Course() { Id = Guid.Parse("1d6940a7-7035-4bc0-baa4-06174e05e356"), Name = "Course 21", SubjectId = "GDS003", MentorId = Guid.Parse("3f0c7479-25cd-4863-962e-a317ab219395"), StartDate = DateTime.Parse("2021-10-21"), Price = 100, MajorId = "GD" }
            );
            #endregion

            #region double pk fk

            modelBuilder.Entity<SubjectMajor>().HasKey(s => new { s.MajorId, s.SubjectId });
            modelBuilder.Entity<AvailableMajor>().HasKey(s => new { s.MajorId, s.MentorId });
            modelBuilder.Entity<StudentRegistration>().HasKey(s => new { s.CourseId, s.StudentId });

            #endregion

            #region seed data

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = ConstUserRoles.ADMIN, Name = ConstUserRoles.ADMIN, NormalizedName = ConstUserRoles.ADMIN, ConcurrencyStamp = ConstUserRoles.ADMIN },
            new IdentityRole() { Id = ConstUserRoles.MENTOR, Name = ConstUserRoles.MENTOR, NormalizedName = ConstUserRoles.MENTOR, ConcurrencyStamp = ConstUserRoles.MENTOR },
            new IdentityRole() { Id = ConstUserRoles.STUDENT, Name = ConstUserRoles.STUDENT, NormalizedName = ConstUserRoles.STUDENT, ConcurrencyStamp = ConstUserRoles.STUDENT }
           );

            modelBuilder.Entity<User>().HasData(
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b060", UserName = "admin", NormalizedUserName = "admin", Fullname = "Admin Ne`", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==" }
               );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b060", RoleId = ConstUserRoles.ADMIN },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b061", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b062", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b063", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b064", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b065", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b066", RoleId = ConstUserRoles.STUDENT },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b067", RoleId = ConstUserRoles.STUDENT },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b068", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b069", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b070", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b071", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b072", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b073", RoleId = ConstUserRoles.STUDENT },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b074", RoleId = ConstUserRoles.STUDENT },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b075", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b076", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b077", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b078", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b079", RoleId = ConstUserRoles.MENTOR },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b080", RoleId = ConstUserRoles.STUDENT },
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b081", RoleId = ConstUserRoles.STUDENT }


            );


            #region Seed Student data

            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = Guid.Parse("3c0c7479-25cd-4863-962e-a317ab219379"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b066" },
                new Student() { Id = Guid.Parse("3c0c7479-25cd-4863-962e-a317ab219382"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b067" },
                new Student() { Id = Guid.Parse("3c0c7479-25cd-4863-962e-a317ab219383"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b073" },
                new Student() { Id = Guid.Parse("3c0c7479-25cd-4863-962e-a317ab219385"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b074" },
                new Student() { Id = Guid.Parse("3c0c7479-25cd-4863-962e-a317ab219389"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b080" },
                new Student() { Id = Guid.Parse("3c0c7479-25cd-4863-962e-a317ab219392"), UserId = "3c5ec754-01b1-49cf-94e0-09250222b081" }
            );
            #endregion



            //        modelBuilder.Entity<IdentityRole>().HasData(
            //new IdentityRole() { Id = ConstUserRoles.ADMIN, Name = ConstUserRoles.ADMIN, NormalizedName = ConstUserRoles.ADMIN, ConcurrencyStamp = ConstUserRoles.ADMIN },
            //new IdentityRole() { Id = ConstUserRoles.CUSTOMER, Name = ConstUserRoles.CUSTOMER, NormalizedName = ConstUserRoles.CUSTOMER, ConcurrencyStamp = ConstUserRoles.CUSTOMER },
            //new IdentityRole() { Id = ConstUserRoles.EMPLOYEE, Name = ConstUserRoles.EMPLOYEE, NormalizedName = ConstUserRoles.EMPLOYEE, ConcurrencyStamp = ConstUserRoles.EMPLOYEE }
            //);
            //modelBuilder.Entity<User>().HasData(
            //    new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b060", UserName = "admin", NormalizedUserName = "admin", Fullname = "Admin Ne`", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==" }
            //    );
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b060", RoleId = ConstUserRoles.ADMIN}
            //    );
            #endregion
        }
    }
}
