using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HungryPizzaAPI.Domain.Requests
{
    public class OrderRequest
    {
        public string Identifier { get; set; }

        [JsonProperty("pizzas")] [Required] public List<PizzaRequest> Pizzas { get; set; }

        [JsonProperty("customer")] public CustomerRequest Customer { get; set; }
    }
}