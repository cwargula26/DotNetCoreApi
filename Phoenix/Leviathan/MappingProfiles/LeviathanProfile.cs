using AutoMapper;
using Phoenix.Models;
using Phoenix.Leviathan.Models;

namespace Phoenix.Leviathan.MappingProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, CreateEmployeeModel>()
                .ForMember(dest => dest.telephone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();
        }
    }
}