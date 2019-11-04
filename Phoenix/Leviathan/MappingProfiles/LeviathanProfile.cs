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
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.telephone))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.role))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            // Customer Map
            CreateMap<LeviathanCustomerModel, Customer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.employid))
                .ReverseMap();

            // Order Map
            CreateMap<Order, LeviathanOrderCreateModel>()
                .ForMember(dest => dest.customerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ForMember(dest => dest.cashierId, opt => opt.MapFrom(src => src.CashierId))
                .ForMember(dest => dest.cartTotal, opt => opt.MapFrom(src => src.CartTotal.ToString()));

            CreateMap<LeviathanOrderGetModel, Order>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.customerId))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ForMember(dest => dest.CashierId, opt => opt.MapFrom(src => src.cashierId))
                .ForMember(dest => dest.CartTotal, opt => opt.MapFrom(src => System.Decimal.Parse(src.cartTotal)));
        }
    }
}