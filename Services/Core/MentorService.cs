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
        ResultModel Search(string name, string majorid, string[] subjectid);
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

                var models = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(m => m.User).ToList());
                for (int i = 0; i < models.Count; i++)
                {
                    var mentor = mentors.Find(u => u.UserId == models[i].Id);

                    var subjects = _dbContext.Subjects.Where(s => mentor.SubjectMentors.Select(s => s.SubjectId).Contains(s.Id)).ToList();
                    var majors = _dbContext.Majors.Where(m => mentor.AvailableMajors.Select(m => m.MajorId).Contains(m.Id)).ToList();


                    models[i].Mentor.Subjects = _mapper.Map<List<Subject>, List<SubjectViewModel1>>(subjects);
                    models[i].Mentor.Majors = _mapper.Map<List<Major>, List<MajorViewModel1>>(majors);

                }
                result.Data = models;
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

                var models = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(m => m.User).ToList());

                for (int i = 0; i < models.Count; i++)
                {
                    var mentor = mentors.Find(u => u.UserId == models[i].Id);

                    var subjects = _dbContext.Subjects.Where(s => mentor.SubjectMentors.Select(s => s.SubjectId).Contains(s.Id)).ToList();
                    var majors = _dbContext.Majors.Where(m => mentor.AvailableMajors.Select(m => m.MajorId).Contains(m.Id)).ToList();

                    models[i].Mentor.Subjects = _mapper.Map<List<Subject>, List<SubjectViewModel1>>(subjects);
                    models[i].Mentor.Majors = _mapper.Map<List<Major>, List<MajorViewModel1>>(majors);
                }

                result.Data = models;
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
        public ResultModel Search(string name, string majorid, string[] subjectids)
        {
            var result = new ResultModel();
            List<User> mentorUsers = null;
            List<MentorViewModel> models = null;
            
            try
            {

                mentorUsers = _dbContext.Users.Where(m => (string.IsNullOrEmpty(name) || m.Fullname.Contains(name)) && m.IsEnabledMentor == true).ToList();

                if (string.IsNullOrEmpty(majorid))
                {
                    models = _mapper.Map<List<User>, List<MentorViewModel>>(mentorUsers);
                }
                else
                {
                    var major = _dbContext.Majors.Find(majorid);
                    //Contains(subjectids[0])
                    if (major != null)
                    {
                        List <Mentor> mentors = new List<Mentor>();
                        if(subjectids == null || subjectids.Length == 0)
                        {
                            mentors = _dbContext.Mentors.Include(x => x.SubjectMentors)
                                                 .Where(m => mentorUsers.Select(s => s.Id).Contains(m.UserId)
                                                   && m.AvailableMajors.Select(am => am.MajorId).Contains(major.Id) ).ToList();
                        }else
                        {
                            foreach (string subjectId in subjectids)
                            {
                                var mentor11 = _dbContext.Mentors.Include(x => x.SubjectMentors)
                                                     .Where(m => mentorUsers.Select(s => s.Id).Contains(m.UserId)
                                                       && m.AvailableMajors.Select(am => am.MajorId).Contains(major.Id)
                                                       && !mentors.Contains(m)
                                                       && (subjectids == null || subjectids.Length == 0 ||
                                                       m.SubjectMentors.Select(sm => sm.SubjectId).Contains(subjectId)));
                                mentors.AddRange(mentor11);
                            }
                        }
                      

                       

                        models = _mapper.Map<List<User>, List<MentorViewModel>>(mentors.Select(s => s.User).ToList());
                    }
                    else
                    {
                        models = _mapper.Map<List<User>, List<MentorViewModel>>(mentorUsers);
                    }
                }

                for (int i = 0; i < models.Count; i++)
                {
                    var mentor = mentorUsers.Find( u => u.Id == models[i].Id).Mentor;

                    var subjects = _dbContext.Subjects.Where(s => mentor.SubjectMentors.Select(s => s.SubjectId).Contains(s.Id)).ToList();
                    var majors = _dbContext.Majors.Where(m => mentor.AvailableMajors.Select(m => m.MajorId).Contains(m.Id)).ToList();


                    models[i].Mentor.Subjects = _mapper.Map<List<Subject>, List<SubjectViewModel1>>(subjects);
                    models[i].Mentor.Majors = _mapper.Map<List<Major>, List<MajorViewModel1>>(majors);
                    
                }

                result.Data = models;

                /* var mentor1 = _dbContext.Mentors.Include(x => x.SubjectMentors)
                     .Where(m => mentors.Select(s => s.Id).Contains(m.UserId) && (string.IsNullOrEmpty(subjectids[0]) || m.SubjectMentors.Select(s => s.SubjectId).Contains(subjectids[0])));*/

                //   result.Data = _mapper.Map<List<User>, List<MentorViewModel>>(mentor1.Select(s => s.User).ToList());
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
                var mentor = new Mentor()
                {
                    About = model.About,
                    Company = model.Company,
                    IsGraduted = model.IsGraduted,
                    UserId = model.UserId
                };

                var newSubjects = _dbContext.Subjects.Where(s => model.SubjectIds.Contains(s.Id)).ToList();
                var newMajors = _dbContext.Majors.Where(s => model.MajorIds.Contains(s.Id)).ToList();

                foreach (var subject in newSubjects)
                {
                    mentor.SubjectMentors.Add(new SubjectMentor() { SubjectId = subject.Id, MentorId = mentor.Id });
                }

                foreach (var major in newMajors)
                {
                    mentor.AvailableMajors.Add(new AvailableMajor() { MajorId = major.Id, MentorId = mentor.Id });
                }


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
                mentor.Company = model.Company;
                mentor.IsGraduted = model.IsGraduted;

                mentor.User.AvatarUrl = model.AvatarUrl;
                mentor.User.PhoneNumber = model.PhoneNumber;


                mentor.User.Fullname = model.Fullname;
                mentor.User.Address = model.Address;

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
