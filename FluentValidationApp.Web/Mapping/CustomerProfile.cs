using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>()
               .ForMember(dest => dest.Isım, opt => opt.MapFrom(x => x.Name))
               .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
               .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age));
               //.ForMember(dest => dest.CreditCardNumber, opt => opt.MapFrom(x => x.CreditCard.Number)) flattening

        }
    }
}