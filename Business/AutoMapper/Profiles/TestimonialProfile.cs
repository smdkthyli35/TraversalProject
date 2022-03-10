using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Profiles
{
    public class TestimonialProfile : Profile
    {
        public TestimonialProfile()
        {
            CreateMap<TestimonialAddDto, Testimonial>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now)).ReverseMap();
            CreateMap<TestimonialUpdateDto, Testimonial>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now)).ReverseMap();
        }
    }
}
