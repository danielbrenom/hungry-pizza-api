using System.Collections.Generic;

namespace HungryPizzaAPI.Domain.Requests
{
    public class PizzaRequest
    {
        public List<string> Tastes { get; set; }
        public float Price { get; set; }
    }
}