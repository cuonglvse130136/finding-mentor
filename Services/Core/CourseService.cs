﻿using AutoMapper;
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
        ResultModel Add(CourseAddModels model);
        ResultModel Update(Guid id, CourseUpdateModels model);
        ResultModel Delete(Guid id);
        ResultModel Search(string name);
        ResultModel RecommendCourse(string userId, string role);
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
                var course = _dbContext.Courses.Where(s => id == null || (s.IsDeleted == false && s.Id == id)).ToList();

                
                result.Data = _mapper.Map<List<Course>, List<CourseViewModel>>(course);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel Add(CourseAddModels model)
        {
            var result = new ResultModel();
            try
            {
                var major = _mapper.Map<CourseAddModels, Course>(model);

                _dbContext.Add(major);
                _dbContext.SaveChanges();

                result.Data = major.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel Search(string name)
        {
            var result = new ResultModel();
            try
            {
                var courses = _dbContext.Courses.Where(x=>x.Name.Contains(name)).ToList();

                result.Data = _mapper.Map<List<Course>, List<CourseViewModel>>(courses);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel RecommendCourse(string userId, string role)
        {
            var result = new ResultModel();
            try
            {
                var majorId = _dbContext.Users.FirstOrDefault(s => s.Id == userId).MajorId;


                //var courses = _dbContext.Courses.Include(m => m.User).Where(s => s.MajorId == users.MajorId).OrderByDescending(s => s.Rating).Take(5).ToList();

                var courses = _dbContext.Courses.Where(c => c.MajorId == majorId).OrderByDescending(c => c.Rating).Take(5).ToList();


                result.Data = _mapper.Map<List<Course>, List<CourseViewModel>>(courses);
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
                course.MentorId = model.MentorId;
                course.Price = model.Price;
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
    }
}
