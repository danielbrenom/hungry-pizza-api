using System;
using System.Collections.Generic;
using System.IO;
using HungryPizzaAPI.Domain.Requests;
using HungryPizzaAPI.Domain.Responses;

namespace HungryPizzaAPITest
{
    public static class OrderFixtures
    {
        public static OrderResponse GetMockOrderResponse()
        {
            return new OrderResponse
            {
                Customer = new CustomerRequest
                {
                    CPF = "00000000000",
                    Name = "Test",
                    Address = "Test",
                    CEP = "00000000"
                },
                Identifier = DateTime.Now.ToString("s"),
                Pizzas = new List<PizzaResponse>
                    {new PizzaResponse {Price = 50f, Tastes = new List<string> {"3 Queijos"}}},
                Total = "50"
            };
        }

        public static OrderRequest GetMockOrderRequest()
        {
            return new OrderRequest
            {
                Customer = new CustomerRequest
                {
                    CPF = "00000000000",
                    Name = "Test",
                    Address = "Test",
                    CEP = "00000000"
                },
                Identifier = DateTime.Now.ToString("s"),
                Pizzas = new List<PizzaRequest>
                    {new PizzaRequest {Price = 50f, Tastes = new List<string> {"3 Queijos"}}}
            };
        }

        public static string GetOrderRequestJson()
        {
            return File.ReadAllText("Fixtures/order.json").Replace("\r\n", "");
        }
    }
}