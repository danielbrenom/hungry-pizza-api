using AutoMapper;
using HungryPizzaAPI.Domain.Models.Collections;
using HungryPizzaAPI.Domain.Models.Tables;
using HungryPizzaAPI.Domain.Requests;
using HungryPizzaAPI.Domain.Responses;

namespace HungryPizzaAPI.Domain.Configurations
{
    public class MapperConfigurator : Profile
    {
        public MapperConfigurator()
        {
            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.Identifier,
                    opt => opt.MapFrom(src => src.OrderTransaction));
            CreateMap<PizzaRequest, Pizza>().ReverseMap();
            CreateMap<Pizza, PizzaResponse>();
            CreateMap<CustomerRequest, Customer>().ReverseMap();
        }
    }
}