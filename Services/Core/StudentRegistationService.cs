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
    public interface IStudentRegistation
    {

    }

    public class StudentRegistationService : IStudentRegistation
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public StudentRegistationService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public ResultModel Get(Guid courseId)
        {
            var result = new ResultModel();
            try
            {
               
                var stu = _dbContext.StudentRegistrations.Include(s => s.Student).ThenInclude(s => s.User)
                                                         .Where(s => s.CourseId == courseId && s.IsDeleted == false).ToList();

                List<StudentRegistationModels> stuReg = new List<StudentRegistationModels>();
                if (stu != null && stu.Count > 0 )
                {
                    foreach (var s in stu)
                    {
                        StudentRegistationModels model = new StudentRegistationModels()
                        {
                            Id = s.StudentId.ToString(),
                            Fullname = s.Student.User.Fullname,
                            MajorId = s.Student.User.MajorId,
                            StartDate = s.DateCreated
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
