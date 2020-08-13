using System.Collections.Generic;
using HungryPizzaAPI.Domain.Models.Collections;
using HungryPizzaAPI.Domain.Models.Tables;
using Newtonsoft.Json;

namespace HungryPizzaAPI.Domain.Requests
{
    public class Order
    {
        public string Identifier { get; set; }
        [JsonProperty("pizzas")]
        public List<Pizza> Pizzas { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    }
}