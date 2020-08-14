using System.Collections.Generic;
using AutoMapper;
using HungryPizzaAPI.Domain.Configurations;
using HungryPizzaAPI.Domain.Models.Collections;
using MongoDB.Driver;

namespace HungryPizzaAPI.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _orders;
        private readonly IMapper _mapper;

        public OrderService(IHungryPizzaMongoSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.OrdersCollectionName);
            _mapper = mapper;
        }

        public List<Domain.Requests.Order> Get()
        {
            var orders = _orders.Find(order => true).ToList();
            return _mapper.Map<List<Domain.Requests.Order>>(orders);
        }

        public List<Order> Get(string cpf) =>  _orders.Find(order => order.Customer.CPF == cpf).ToList();

        public Domain.Requests.Order Create(Domain.Requests.Order order)
        {
            var newOrder = _mapper.Map<Order>(order);
            newOrder.Pizzas.ForEach(pizza => { 
                pizza.Price = 10;
                newOrder.Total += 10;
            });
            _orders.InsertOne(newOrder);
            return _mapper.Map<Domain.Requests.Order>(newOrder);
        }
    }
}