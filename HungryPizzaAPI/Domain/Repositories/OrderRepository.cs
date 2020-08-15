﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using HungryPizzaAPI.Domain.Configurations;
using HungryPizzaAPI.Domain.Models.Collections;
using HungryPizzaAPI.Domain.Models.Tables;
using HungryPizzaAPI.Domain.Requests;
using HungryPizzaAPI.Domain.Responses;
using MongoDB.Driver;

namespace HungryPizzaAPI.Domain.Repositories
{
    public class OrderRepository
    {
        private readonly IMongoCollection<Order> _orders;
        private readonly DatabaseContext _database;
        private readonly IMapper _mapper;
        private OrderRequest _orderRequest;

        public OrderRepository(IHungryPizzaMongoSettings settings,DatabaseContext databaseContext, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.OrdersCollectionName);
            _mapper = mapper;
            _database = databaseContext;
        }

        public List<OrderResponse> Get() =>
            _mapper.Map<List<OrderResponse>>(_orders.Find(order => true).ToList());

        public List<OrderResponse> Get(string cpf) =>
            _mapper.Map<List<OrderResponse>>(_orders.Find(order => order.Customer.CPF == cpf).ToList());

        public OrderResponse Place(OrderRequest orderRequest)
        {
            _orderRequest = orderRequest;
            if (_orderRequest.Pizzas.FirstOrDefault(pizza => pizza.Tastes.Count > 2) != null)
            {
                OrderExceptions.PizzaTastesExceedLimit();
            }
            CheckCustomer();
            return Create(_mapper.Map<Order>(_orderRequest));
        }

        private OrderResponse Create(Order order)
        {
            order.Pizzas.ForEach(pizza =>
            {
                pizza.Tastes.ForEach(tastes =>
                {
                    var taste = _database.Tastes.FirstOrDefault(record => record.Name.Contains(tastes));
                    if (taste is null) return;
                    pizza.Price += taste.Price;
                    order.Total += taste.Price;
                });
            });
            order.OrderTransaction = DateTime.Now.ToString("yyyyMMdHHmmssffff");
            _orders.InsertOne(order);
            return _mapper.Map<OrderResponse>(order);
        }

        private void CheckCustomer()
        {
            var customer = _database.Customers
                .FirstOrDefault(records => records.CPF == _orderRequest.Customer.CPF);
            if (customer is null && _orderRequest.Customer.Address is null && 
                _orderRequest.Customer.CEP is null && _orderRequest.Customer.CEP is null)
            {
                OrderExceptions.CustomerOrAddressNotFound();
            }
            if (_orderRequest.Customer.Address is null && customer != null)
            {
                _orderRequest.Customer = _mapper.Map<CustomerRequest>(customer);
            }

            if (!(customer is null)) return;
            _database.Customers.Add(_mapper.Map<Customer>(_orderRequest.Customer));
            _database.SaveChanges();
        }
    }
}