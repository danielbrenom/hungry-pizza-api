using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HungryPizzaAPI.Domain.Models.Collections
{
    public class Pizza
    {
        private IList<string> _tastes;
        private int _price;

        public Pizza()
        {
            _tastes = new List<string>();
            _price = 0;
        }

        public void addTaste(string taste)
        {
            if (_tastes.Count > 2) return;
            _tastes.Add(taste);
        }

        public IList<string> getTastes()
        {
            return _tastes;
        }

        public void setPrice(int price)
        {
            _price = price;
        }

        public int getPrice()
        {
            return _price;
        }
    }
}