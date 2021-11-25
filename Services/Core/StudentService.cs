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
    public interface IStudentService
    {
        ResultModel Get(Guid? id);
        ResultModel Get(string userId);
        ResultModel Create(StudentAddModel model);
        ResultModel Update(Guid id, StudentUpdateModel model);
        ResultModel UpdateMajor(string id, string majorid);
        ResultModel Delete(Guid id);
        ResultModel Erroll(StudentRegistationModel model);
    }
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public StudentService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public ResultModel Get(Guid? id)
        {
            var result = new ResultModel();
            try
            {
                var students = _dbContext.Students.Where(s => id == null || (s.Id == id)).ToList();

                result.Data = _mapper.Map<List<Student>, List<StudentViewModel>>(students);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Get(string userId)
        {
            var result = new ResultModel();
            try
            {
                var student = _dbContext.Students.Where(s=>s.UserId == userId).FirstOrDefault();
                var data = _mapper.Map<Student, StudentViewModel>(student);
                data.MajorId = student.User.MajorId;
                result.Data = data;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel Create(StudentAddModel model)
        {
            var result = new ResultModel();
            try
            {
                var student = _mapper.Map<StudentAddModel, Student>(model);

                _dbContext.Add(student);
                _dbContext.SaveChanges();

                result.Data = student.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(Guid id, StudentUpdateModel model)
        {
            var result = new ResultModel();
            try
            {
                var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    throw new Exception("Invalid Id");
                }

                student = _mapper.Map<StudentUpdateModel, Student>(model);


                _dbContext.Update(student);
                _dbContext.SaveChanges();

                result.Data = student.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel UpdateMajor (string id, string majorid)
        {
            var result = new ResultModel();
            try
            {
                var student = _dbContext.Students.FirstOrDefault(s => s.UserId == id);

                if (student == null)
                {
                    throw new Exception("Invalid Id");
                }

                var user = _dbContext.Users.FirstOrDefault(u => u.Id == student.UserId);

                user.MajorId = majorid;

                _dbContext.Update(user);
                _dbContext.SaveChanges();

                result.Data = student.Id;
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
                var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    throw new Exception("Invalid Id");
                }



                _dbContext.Update(student);
                _dbContext.SaveChanges();

                result.Data = student.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }


        public ResultModel Erroll(StudentRegistationModel model)
        {
            var result = new ResultModel();
            try
            {
                var student = _dbContext.User.Find(model.StudentId.ToString());
                var course = _dbContext.Courses.Find(model.CourseId);

                if(student.Balance < course.Price)
                {
                    throw new Exception("Balance is not enough!");
                }

               // var registration = _mapper.Map<StudentRegistationModel, StudentRegistration>(model);
                var studentRegistration = new StudentRegistration() { CourseId = course.Id, StudentId = student.Student.Id, StartDate = model.StartDate };
                student.Balance -= course.Price;

                _dbContext.Add(studentRegistration);
                _dbContext.Update(student);
                _dbContext.SaveChanges();

                
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
