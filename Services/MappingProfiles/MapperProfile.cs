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
            CreateMap<UserRegisterModel, User>()
                .ReverseMap();
            //.ForMember(m => m.PhoneNumber, map => map.MapFrom(m1 => m1.Phone))
        }
    }
}
