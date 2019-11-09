using AutoMapper;
using Phoenix.Models;
using Phoenix.Leviathan.Models;

namespace Phoenix.Leviathan.MappingProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // Employee Map
            CreateMap<LeviathanEmployeeModel, Employee>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.telephone))
                .ReverseMap();

            // Customer Map
            CreateMap<LeviathanCustomerModel, Customer>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.employid))
                .ReverseMap();

            // Order Map
            CreateMap<Order, LeviathanOrderCreateModel>()
                .ForMember(dest => dest.cartTotal, opt => opt.MapFrom(src => src.CartTotal.ToString()));

            CreateMap<LeviathanOrderGetModel, Order>()
                .ForMember(dest => dest.CartTotal, opt => opt.MapFrom(src => System.Decimal.Parse(src.cartTotal.ToString())));
        }
    }
}