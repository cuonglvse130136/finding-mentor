using AutoMapper;
using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MappingProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // USER MODEL
            CreateMap<UserRegisterModel, User>()
                .ReverseMap();
            CreateMap<UserViewModels, User>()
                .ReverseMap();

            //MAJOR MODEL
            CreateMap<MajorViewModel, Major>()
                .ReverseMap();
            CreateMap<Major, MajorViewModel1>()
                .ReverseMap();
            CreateMap<MajorAddModel, Major>()
                 .ReverseMap();
            CreateMap<MajorUpdateModel, Major>()
                 .ReverseMap();

            //MENTOR MODEL
            CreateMap<MentorAddModel, Mentor>()
                .ReverseMap();
            CreateMap<Mentor, MentorViewModel>()
                .ForMember(m => m.Fullname, map => map.MapFrom(m1 => m1.User.Fullname))
                .ForMember(m => m.BirthDate, map => map.MapFrom(m1 => m1.User.BirthDate))
                .ForMember(m => m.Address, map => map.MapFrom(m1 => m1.User.Address))
                .ForMember(m => m.Gender, map => map.MapFrom(m1 => m1.User.Gender))
                .ForMember(m => m.IsEnabledMentor, map => map.MapFrom(m1 => m1.User.IsEnabledMentor))
                .ReverseMap();
            CreateMap<MentorUpdateModel, Mentor>()
                .ReverseMap();
            CreateMap<User, MentorViewModel>()
                .ReverseMap();

            //askldj
            CreateMap<Subject, SubjectViewModel1>()
               .ReverseMap();

            CreateMap<Mentor, MentorDataModel>()
                 // .ForMember(m => m.Subjects, map => map.Ignore())
               // .ForMember(m => m.Majors, map => map.MapFrom(m1 => m1.AvailableMajors))
                 .ReverseMap();


            //STUDENT MODEL
            CreateMap<StudentAddModel, Student>()
                .ReverseMap();
            CreateMap<StudentViewModel, Student>()
                .ReverseMap();
            CreateMap<StudentUpdateModel, Student>()
                .ReverseMap();

            //COURSE MODEL
            CreateMap<CourseAddModels, Course>()
                 .ReverseMap();
            CreateMap<CourseUpdateModels, Course>()
                .ReverseMap();
            CreateMap<CourseViewModel, Course>()
                .ReverseMap();
            // SUBJECT MODEL
            CreateMap<SubjectAddModels, Subject>()
                 .ReverseMap();
            CreateMap<SubjectUpdateModels, Subject>()
                .ReverseMap();
            CreateMap<SubjectViewModel, Subject>()
                .ReverseMap();
            //.ForMember(m => m.PhoneNumber, map => map.MapFrom(m1 => m1.Phone))
        }
    }
}
