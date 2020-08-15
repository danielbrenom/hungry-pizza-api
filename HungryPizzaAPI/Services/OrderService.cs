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

        public List<OrderResponse> Get() => _orderRepository.Get();

        public List<OrderResponse> Get(string cpf) =>  _orderRepository.Get(cpf);

        public OrderResponse Place(OrderRequest orderRequest) => _orderRepository.Place(orderRequest);
    }
}