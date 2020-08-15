using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HungryPizzaAPI.Domain.Models.Collections
{
    public class Pizza
    {
        public List<string> Tastes { get; set; }
        public float Price { get; set; }
    }
}