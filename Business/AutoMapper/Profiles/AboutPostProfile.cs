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
    public class AboutPostProfile : Profile
    {
        public AboutPostProfile()
        {
            CreateMap<AboutPostAddDto, AboutPost>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now)).ReverseMap();
            CreateMap<AboutPostUpdateDto, AboutPost>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
