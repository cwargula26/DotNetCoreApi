using AutoMapper;
using Phoenix.Models;
using Phoenix.Leviathan.Models;

namespace Phoenix.Leviathan.MappingProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // CreateMap<Employee, LeviathanEmployeeModel>()
            //     .ForMember(dest => dest.telephone, opt => opt.MapFrom(src => src.PhoneNumber))
            CreateMap<LeviathanEmployeeModel, Employee>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.telephone))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.role))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}