using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CVApp.Data;
using CVApp.ViewModels;

namespace CVApp.Profiles
{
    public class CvProfile : Profile
    {
        public CvProfile()
        {
            CreateMap<CreateCVViewModel, CV>()
                .ForMember(dest => dest.Name , opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.GenderRadio))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.date))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.SkillsChecked))
                ;
            CreateMap<string, Skill>()
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src))
                ;
            CreateMap<CV, DetailsViewModel>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == 'f' ? "female" : "male"))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToShortDateString()))
                ;
            CreateMap<CV, UpdateViewModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name.Split(' ', StringSplitOptions.None)[0]))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => string.Join(' ', src.Name.Split(' ',StringSplitOptions.None).Skip(1))))
                ;
            CreateMap<UpdateViewModel, CV>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.GenderRadio))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.date))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.SkillsChecked))
                ;
            CreateMap<CV, IndexViewModel>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == 'f' ? "female" : "male"))
                ;
        }
    }
}
