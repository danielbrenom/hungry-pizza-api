using System;
using System.Collections.Generic;
using HungryPizzaAPI.Domain.Models.Tables;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HungryPizzaAPI.Domain.Models.Collections
{
    public class Order
    {
        public Customer Customer;
        public List<Pizza> Pizzas;

        public Order()
        {
            Pizzas = new List<Pizza>();
            Total = 0f;
            Customer = new Customer();
            CreatedAt = DateTime.Now.ToString("s");
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string OrderTransaction { get; set; }
        public float Total { get; set; }
        private string CreatedAt { get; }
    }
}