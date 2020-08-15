using System.Collections.Generic;
using Newtonsoft.Json;

namespace HungryPizzaAPI.Domain.Responses
{
    public class PizzaResponse
    {
        [JsonProperty("tastes")]
        public List<string> Tastes { get; set; }
        [JsonProperty("price")]
        public float Price { get; set; }
    }
}