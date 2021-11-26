using AutoMapper;
using Data.DbContext;
using Data.Entities;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Core
{
    public interface ICourseService
    {
        ResultModel Get(Guid? id);
        ResultModel GetMenteeList(Guid courseId);
        ResultModel GetMenteeList(Guid? id);
        ResultModel GetCourseOfMentor(string userId);
        ResultModel Add(CourseAddModels model, string userId);
        ResultModel Update(Guid id, CourseUpdateModels model);
        ResultModel Delete(Guid id);
        ResultModel Search(string name, string majorid, string[] subjectid);
        ResultModel RecommendCourse(string userId);
        ResultModel GetCourseOfStudent(string userId);

        ResultModel UpdateImageUrl(Guid id, UpdateImageUrlModel model);


    }

    public class CourseService : ICourseService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CourseService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ResultModel Get(Guid? id)
        {
            var result = new ResultModel();
            try
            {
                var course = _dbContext.Courses.Where(s => id == null || (s.IsDeleted == false && s.Id == id)).FirstOrDefault();


                var courseResult = _mapper.Map<Course, CourseViewModel>(course);

                var mentorUser = _dbContext.Mentors.Where(s => s.Id == course.MentorId).First().User;
                courseResult.MentorName = mentorUser.Fullname;
                courseResult.MentorId = Guid.Parse(mentorUser.Id);

                var s1 = mentorUser.Mentor.AvailableMajors.Select(s => s.Major);
                var s2 = s1.Select(m => m.SubjectMajors.Select(sm => sm.SubjectId));


                
                var major = mentorUser.Mentor.AvailableMajors.Select(s => s.Major).Where(m => m.SubjectMajors.Select(sm => sm.SubjectId).Contains(courseResult.SubjectId));

                
                if(major.Count() != 0)
                {
                    courseResult.MajorId = major.First().Id;
                }
                result.Data = courseResult;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetMenteeList(Guid? id)
        {
            var result = new ResultModel();
            /* try
             {
                 var course = _dbContext.Courses.Where(s => id == null || (s.IsDeleted == false && s.Id == id)).FirstOrDefault().StudentRegistrations;


                 var courseResult = _mapper.Map<Course, CourseViewModel>(course);

                 var mentorName = _dbContext.Mentors.Where(s => s.Id == course.MentorId).First().User.Fullname;
                 courseResult.MentorName = mentorName;
                 result.Data = courseResult;
                 result.Success = true;
             }
             catch (Exception e)
             {
                 result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
             }*/
            return result;
        }
        public ResultModel GetCourseOfMentor(string userId)
        {
            var result = new ResultModel();
            try
            {
                var am = _dbContext.Mentors.Where(m => m.UserId == userId).FirstOrDefault().AvailableMajors;
                if (am.Count == 0) return result;

                var mentorId = _dbContext.Mentors.FirstOrDefault(m => m.UserId == userId).Id;
                var course = _dbContext.Courses.Where(s => s.MentorId == mentorId && s.IsDeleted == false).ToList();

                var coursesData = _mapper.Map<List<Course>, List<CourseViewModel>>(course);
                foreach (var c in coursesData)
                {
                    c.MentorName = _dbContext.Mentors.Where(m => c.MentorId == m.Id).FirstOrDefault().User.Fullname;
                }

                result.Data = coursesData;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel GetCourseOfStudent(string userId)
        {
            var result = new ResultModel();
            try
            {
                var students = _dbContext.Students.Where(s => s.UserId == userId).FirstOrDefault();


                var course = _dbContext.Courses.Where(m => students.StudentRegistrations.Select(m => m.CourseId)
                .Contains(m.Id)).ToList();

                var coursesData = _mapper.Map<List<Course>, List<CourseViewModel>>(course);
                foreach (var c in coursesData)
                {
                    c.MentorName = _dbContext.Mentors.Where(m => c.MentorId == m.Id).FirstOrDefault().User.Fullname;
                }

                result.Data = coursesData;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel Add(CourseAddModels model, string userId)
        {
            var result = new ResultModel();
            try
            {
                var mentorId = _dbContext.Mentors.FirstOrDefault(m => m.UserId == userId).Id;
                var course = _mapper.Map<CourseAddModels, Course>(model);

                course.MentorId = mentorId;
                _dbContext.Add(course);
                _dbContext.SaveChanges();

                result.Data = course.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel Search(string name, string majorid, string[] subjectids)
        {

            var result = new ResultModel();
            List<Course> courses = null;
            try
            {

                if (string.IsNullOrEmpty(majorid))
                {
                    courses = _dbContext.Courses
                    .Where(x => (string.IsNullOrEmpty(name) || x.Name.Contains(name))).ToList();
                }
                else
                {
                    var major = _dbContext.Majors.Find(majorid);
                    
                    if (major != null)
                    {
                        var subjectInmMjor = major.SubjectMajors.Select(sm=> sm.Subject);

                        courses = _dbContext.Courses.Include(c=>c.Subject)
                                 .Where(x => (string.IsNullOrEmpty(name) || x.Name.Contains(name)) 
                                      && (string.IsNullOrEmpty(majorid) || subjectInmMjor.Contains(x.Subject))
                                      && (subjectids == null || subjectids.Length == 0 || subjectids.Contains(x.SubjectId)))
                                .ToList();
                    }

                }

                var coursesData  = _mapper.Map<List<Course>, List<CourseViewModel>>(courses);

                foreach (var c in coursesData)
                {
                    c.MentorName = _dbContext.Mentors.Where(m => c.MentorId == m.Id).FirstOrDefault().User.Fullname;
                }

                result.Data = coursesData;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel RecommendCourse(string userId)
        {
            var result = new ResultModel();
            try
            {
                var majorId = _dbContext.Users.FirstOrDefault(s => s.Id == userId).MajorId;


                //var courses = _dbContext.Courses.Include(m => m.User).Where(s => s.MajorId == users.MajorId).OrderByDescending(s => s.Rating).Take(5).ToList();

                var courses = _dbContext.Courses.Where(c => c.MajorId == majorId).OrderByDescending(c => c.Rating).Take(5).ToList();
                var coursesData = _mapper.Map<List<Course>, List<CourseViewModel>>(courses);
                foreach (var c in coursesData)
                {
                    c.MentorName = _dbContext.Mentors.Where(m => c.MentorId == m.Id).FirstOrDefault().User.Fullname;
                }




                result.Data = coursesData;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(Guid id, CourseUpdateModels model)
        {
            var result = new ResultModel();
            try
            {
                var course = _dbContext.Courses.FirstOrDefault(s => s.Id == id);

                if (course == null)
                {
                    throw new Exception("Invalid Id");
                }

                course.Name = model.Name;
                course.Price = model.Price;
                course.Duration = model.Duration;
                course.ImageUrl = model.ImageUrl;
                course.Description = model.Description;
                course.SubjectId = model.SubjectId;
                course.DateUpdated = DateTime.Now;

                _dbContext.Update(course);
                _dbContext.SaveChanges();

                result.Data = course.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }


        public ResultModel Delete(Guid id)
        {
            var result = new ResultModel();
            try
            {
                var course = _dbContext.Courses.FirstOrDefault(s => s.Id == id);

                if (course == null)
                {
                    throw new Exception("Invalid Id");
                }

                course.IsDeleted = true;
                //service.DateUpdated = DateTime.Now;

                _dbContext.Update(course);
                _dbContext.SaveChanges();

                result.Data = course.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel UpdateImageUrl(Guid id, UpdateImageUrlModel model)
        {
            var result = new ResultModel();
            try
            {
                var course = _dbContext.Courses.FirstOrDefault(s => s.Id == id);

                if (course == null)
                {
                    throw new Exception("Invalid Id");
                }

                course.ImageUrl = model.ImageUrl;

                _dbContext.Update(course);
                _dbContext.SaveChanges();

                result.Data = course.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetMenteeList(Guid courseId)
        {
            var result = new ResultModel();
            try
            {

                var stu = _dbContext.StudentRegistrations.Include(s => s.Student).ThenInclude(s => s.User)
                                                         .Where(s => s.CourseId == courseId).ToList();

                List<StudentRegistationModels> stuReg = new List<StudentRegistationModels>();
                if (stu != null && stu.Count > 0)
                {
                    foreach (var s in stu)
                    {
                        StudentRegistationModels model = new StudentRegistationModels()
                        {
                            Id = s.Student.UserId,
                            Fullname = s.Student.User.Fullname,
                            MajorId = s.Student.User.MajorId,
                            StartDate = s.StartDate,
                            AvatarUrl = s.Student.User.AvatarUrl
                        };
                        stuReg.Add(model);
                    }
                }

                result.Data = stuReg;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
    }
}
