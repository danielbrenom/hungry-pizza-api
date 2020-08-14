using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HungryPizzaAPI.Domain.Models.Collections
{
    public class Pizza
    {
        public List<string> Tastes;
        public int Price;

        public Pizza()
        {
            Tastes = new List<string>();
            Price = 0;
        }

        public void addTaste(string taste)
        {
            if (Tastes.Count > 2) return;
            Tastes.Add(taste);
        }

        public IList<string> getTastes()
        {
            return Tastes;
        }

        public void setPrice(int price)
        {
            Price = price;
        }

        public int getPrice()
        {
            return Price;
        }
    }
}