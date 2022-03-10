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
    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            CreateMap<DestinationAddDto, Destination>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now)).ReverseMap();
            CreateMap<DestinationUpdateDto, Destination>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now)).ReverseMap();
        }
    }
}
