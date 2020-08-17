using System.Collections.Generic;
using HungryPizzaAPI.Domain.Requests;
using HungryPizzaAPI.Domain.Responses;

namespace HungryPizzaAPI.Domain.Interfaces
{
    public interface IOrderService
    {
        public List<OrderResponse> Get();
        public List<OrderResponse> Get(string cpf);
        public OrderResponse Place(OrderRequest orderRequest);
    }
}