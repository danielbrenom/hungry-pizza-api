using System.Collections.Generic;
using HungryPizzaAPI.Domain.Repositories;
using HungryPizzaAPI.Domain.Requests;
using HungryPizzaAPI.Domain.Responses;

namespace HungryPizzaAPI.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderResponse> Get()
        {
            return _orderRepository.Get();
        }

        public List<OrderResponse> Get(string cpf)
        {
            return _orderRepository.Get(cpf);
        }

        public OrderResponse Place(OrderRequest orderRequest)
        {
            return _orderRepository.Place(orderRequest);
        }
    }
}