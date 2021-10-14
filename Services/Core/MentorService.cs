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
    public interface IMentorService
    {
        ResultModel Get(Guid? id);
        ResultModel Create(MentorAddModel model);
        ResultModel Update(Guid id, MentorUpdateModel model);
        ResultModel Delete(Guid id);
        ResultModel RecommendMentorByMajor(string userId);
        ResultModel Search(string name);
        ResultModel RecommendMentor();
    }
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public MentorService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public ResultModel Get(Guid? id)
        {
            var result = new ResultModel();
            try
            {
                var mentors = _dbContext.Mentors.Include(m => m.User).Where(s => id == null || (s.Id == id)).ToList();

                result.Data = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(m => m.User).ToList());
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel RecommendMentorByMajor(string userId)
        {
            var result = new ResultModel();
            try
            {
                var users = _dbContext.Users.FirstOrDefault(s => s.Id == userId);

                var mentors = _dbContext.Mentors.Include(m => m.User).Where(s => s.MajorId == users.MajorId).OrderByDescending(s => s.Rating ).Take(5).ToList();
                                                
                
                result.Data = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(m => m.User).ToList());
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel RecommendMentor()
        {
            var result = new ResultModel();
            try
            {
                var mentors = _dbContext.Mentors.Include(m => m.User).OrderByDescending(s => s.Rating).Take(5).ToList();

                result.Data = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(m => m.User).ToList());
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        //public ResultModel Test()
        //{
        //    var result = new ResultModel();
        //    try
        //    {
        //        //tìm  một cái course có th mentor tên là lộc, để ý đề và sử dụng não
        //        var courses = _dbContext.Courses.Include(s => s.Mentor).Where(s => s.Mentor.User.Fullname.Contains("Loc")).ToList();



        //        result.Data = _mapper.Map<List<Mentor>, List<MentorViewModel>>(mentors);
        //        result.Success = true;
        //    }
        //    catch (Exception e)
        //    {
        //        result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
        //    }
        //    return result;
        //}
        public ResultModel Search(string name)
        {
            var result = new ResultModel();
            try
            {
                var mentors = _dbContext.Mentors.Include(m => m.User).Where(x => x.User.Fullname.Contains(name)).ToList();

                result.Data = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(m => m.User).ToList());
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel Create(MentorAddModel model)
        {
            var result = new ResultModel();
            try
            {
                var mentor = _mapper.Map<MentorAddModel, Mentor>(model);

                _dbContext.Add(mentor);
                _dbContext.SaveChanges();

                result.Data = mentor.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(Guid id, MentorUpdateModel model)
        {
            var result = new ResultModel();
            try
            {
                var mentor = _dbContext.Mentors.FirstOrDefault(s => s.Id == id);

                if (mentor == null)
                {
                    throw new Exception("Invalid Id");
                }

                mentor = _mapper.Map<MentorUpdateModel, Mentor>(model);
                

                _dbContext.Update(mentor);
                _dbContext.SaveChanges();

                result.Data = mentor.Id;
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
                var mentor = _dbContext.Mentors.FirstOrDefault(s => s.Id == id);

                if (mentor == null)
                {
                    throw new Exception("Invalid Id");
                }

                

                _dbContext.Update(mentor);
                _dbContext.SaveChanges();

                result.Data = mentor.Id;
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
