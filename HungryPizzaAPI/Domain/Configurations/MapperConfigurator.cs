using System.Collections.Generic;
using AutoMapper;
using HungryPizzaAPI.Domain.Requests;

namespace HungryPizzaAPI.Domain.Configurations
{
    public class MapperConfigurator: Profile
    {
        public MapperConfigurator()
        {
            CreateMap<Order, Models.Collections.Order>();
            CreateMap<Models.Collections.Order, Order>().ForMember(
                dest => dest.Identifier, 
                opt => opt.MapFrom(src => src.Id));
            CreateMap<Pizza,Models.Collections.Pizza>().ReverseMap();
            CreateMap<Customer,Models.Tables.Customer>().ReverseMap();
        }
    }
}