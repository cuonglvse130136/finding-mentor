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
            CreateMap<MajorAddModel, Major>()
                 .ReverseMap();
            CreateMap<MajorUpdateModel, Major>()
                 .ReverseMap();

            //COURSE MODEL
            CreateMap<CourseAddModels, Course>()
                 .ReverseMap();
            CreateMap<CourseUpdateModels, Course>()
                .ReverseMap();
            CreateMap<CourseViewModel, Course>()
                .ReverseMap();
            //.ForMember(m => m.PhoneNumber, map => map.MapFrom(m1 => m1.Phone))
        }
    }
}
