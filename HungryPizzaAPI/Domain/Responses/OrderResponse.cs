using System.Collections.Generic;
using HungryPizzaAPI.Domain.Requests;
using Newtonsoft.Json;

namespace HungryPizzaAPI.Domain.Responses
{
    public class OrderResponse
    {
        public string Identifier { get; set; }

        [JsonProperty("pizzas")] public List<PizzaResponse> Pizzas { get; set; }

        [JsonProperty("customer")] public CustomerRequest Customer { get; set; }

        [JsonProperty("order_total")] public string Total { get; set; }
    }
}