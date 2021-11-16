using AutoMapper;
using Data.DbContext;
using Data.Entities;
using Data.StaticData;
using Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Core
{
    public interface IMentorService
    {
        ResultModel Get(Guid? id);
        Task<ResultModel> Create(MentorAddModel model);
        ResultModel Update(Guid id, MentorUpdateModel model);
        ResultModel UpdateMentorProfile(string userId, MentorUpdateModel1 model);
        ResultModel Delete(Guid id);
        ResultModel RecommendMentorByMajor(string userId);
        ResultModel Search(string name);
        ResultModel RecommendMentor();

        ResultModel GetMentorInformation(string id);

        ResultModel GetAvailableMajors(string userId);

    }
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public MentorService(IMapper mapper, AppDbContext dbContext, UserManager<User> userManager)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public ResultModel Get(Guid? id)
        {
            var result = new ResultModel();
            try
            {
                var mentors = _dbContext.Mentors.Include(m => m.User)
                                                .Where(s => id == null || (s.Id == id)).ToList();

                //foreach (var mentor in mentors)
                //{
                //    var subjects = _dbContext.SubjectMentors.Where(s => s.MentorId == mentor.UserId).ToList();

                //    var majors = _dbContext.maj
                //}

                result.Data = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(m => m.User).ToList());
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel GetMentorInformation(string id)
        {
            var result = new ResultModel();
            try
            {
                var user = _dbContext.User.FirstOrDefault(f => f.Id == id);

                var data = _mapper.Map<User, MentorViewModel>(user);

                var mentors = _dbContext.Mentors
                    .Include(m => m.User)
                    .Include(m => m.SubjectMentors)
                    .Include(m => m.AvailableMajors)
                    .Where(s => s.UserId == id)
                    .FirstOrDefault();
                var subjects = _dbContext.Subjects.Where(s => mentors.SubjectMentors.Select(s => s.SubjectId).Contains(s.Id)).ToList();
                var majors = _dbContext.Majors.Where(m => mentors.AvailableMajors.Select(m => m.MajorId).Contains(m.Id)).ToList();


                MentorDataModel mentor = _mapper.Map<Mentor, MentorDataModel>(mentors);
                //  MentorDataModel mentor1 = new MentorDataModel()
                //  {
                //      About = mentors.About,
                //      AvatarUrl = mentors.AvatarUrl,
                //      Company = mentors.Company,
                //      IsGraduted = mentors.IsGraduted,
                //      Rating = mentors.Rating
                //  };
                mentor.Subjects = _mapper.Map<List<Subject>, List<SubjectViewModel1>>(subjects);
                mentor.Majors = _mapper.Map<List<Major>, List<MajorViewModel1>>(majors);
                data.Mentor = mentor;
                /* for (int i = 0; i < mentors.Count; i++)
                 {* /

                 /*}*/


                result.Data = data;
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

                var mentors = _dbContext.Mentors.Include(m => m.User)
                                                .Where(s => s.AvailableMajors.Any(am => am.MajorId == users.MajorId))
                                                .OrderByDescending(s => s.Rating).Take(5).ToList();


                result.Data = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(m => m.User).ToList());
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel GetAvailableMajors(string userId)
        {
            var result = new ResultModel();
            try
            {
                var major = _dbContext.Mentors.Where(m => m.UserId == userId).FirstOrDefault().AvailableMajors.Select(am => am.Major).ToList();

                result.Data = _mapper.Map<List<Major>, List<MajorViewModel>>(major);
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
                //var mentors = _dbContext.Mentors.Include(m => m.User).Where(x => x.User.Fullname.Contains(name)).ToList();

                //result.Data = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(m => m.User).ToList());


                var mentors = _dbContext.Users.Where(m => m.Fullname.Contains(name) && m.IsEnabledMentor == true).ToList();
                result.Data = _mapper.Map<List<User>, List<MentorViewModel>>(mentors);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public async Task<ResultModel> Create(MentorAddModel model)
        {
            var result = new ResultModel();
            try
            {
                var mentor = _mapper.Map<MentorAddModel, Mentor>(model);

                _dbContext.Add(mentor);

                var user = _dbContext.Users.FirstOrDefault(s => s.Id == model.UserId);
                user.IsEnabledMentor = true;
                _dbContext.Update(user);

                foreach (var subjectId in model.SubjectIds)
                {
                    var subjectMentor = new SubjectMentor()
                    {
                        SubjectId = subjectId,
                        MentorId = mentor.Id
                    };
                    _dbContext.Add(subjectMentor);
                }



                _dbContext.SaveChanges();
                await _userManager.AddToRoleAsync(user, ConstUserRoles.MENTOR);
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

        public ResultModel UpdateMentorProfile(string userId, MentorUpdateModel1 model)
        {
            var result = new ResultModel();
            try
            {
                var mentor = _dbContext.Mentors.FirstOrDefault(s => s.UserId == userId);

                if (mentor == null)
                {
                    throw new Exception("Invalid Id");
                }

                //  mentor = _mapper.Map<MentorUpdateModel1, Mentor>(model);


                mentor.About = model.About;
                mentor.AvatarUrl = model.AvatarUrl;
                mentor.Company = model.Company;
                mentor.User.Fullname = model.Fullname;
                mentor.User.Address = model.Address;
                mentor.IsGraduted = model.IsGraduted;
                var newSubjects = _dbContext.Subjects.Where(s => model.SubjectIds.Contains(s.Id)).ToList();
                var newMajors = _dbContext.Majors.Where(s => model.MajorIds.Contains(s.Id)).ToList();
                mentor.SubjectMentors.Clear();
                mentor.AvailableMajors.Clear();
                foreach (var subject in newSubjects)
                {
                    mentor.SubjectMentors.Add(new SubjectMentor() { SubjectId = subject.Id, MentorId = mentor.Id });
                }

                foreach (var major in newMajors)
                {
                    mentor.AvailableMajors.Add(new AvailableMajor() { MajorId = major.Id, MentorId = mentor.Id });
                }

                _dbContext.Mentors.Update(mentor);
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
