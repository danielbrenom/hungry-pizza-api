using System.Collections.Generic;
using HungryPizzaAPI.Domain.Configurations;
using HungryPizzaAPI.Domain.Models.Collections;
using MongoDB.Driver;

namespace HungryPizzaAPI.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(IHungryPizzaMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.OrdersCollectionName);
        }

        public List<Order> Get() =>
            _orders.Find(order => true).ToList();

        public Order Create(Domain.Requests.Order order)
        {
            var newOrder = new Order();
            newOrder.setCustomer(order.Customer);
            return newOrder;
        }
    }
}