using System.Collections.Generic;
using HungryPizzaAPI.Domain.Models.Tables;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HungryPizzaAPI.Domain.Models.Collections
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<Pizza> Pizzas;
        public int Total;
        public Customer Customer;

        public Order()
        {
            Pizzas = new List<Pizza>();
            Total = 0;
            Customer = new Customer();
        }

        public void setCustomer()
        {
            
        }
    }
}