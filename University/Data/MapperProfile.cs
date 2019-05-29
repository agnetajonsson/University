using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;
using University.ViewModels;

namespace University.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentAddViewModel, Student>()
                .ForMember(dest => dest.Enrollments, opt => opt.Ignore())
                .ForPath(dest => dest.Address, opt => opt.MapFrom(model => new Address { City = model.City, Street = model.Street }));
                
        }
    }
}
