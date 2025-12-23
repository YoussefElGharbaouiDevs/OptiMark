using AutoMapper;
using OptiMark.API.DTO;
using OptiMark.DAL.Models;

namespace OptiMark.API.Config;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, AppUser>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId));
    }
}