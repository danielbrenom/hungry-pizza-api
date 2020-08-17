using System.Collections.Generic;
using System.Linq;
using HungryPizzaAPI;
using HungryPizzaAPI.Controllers;
using HungryPizzaAPI.Domain.Interfaces;
using HungryPizzaAPI.Domain.Requests;
using HungryPizzaAPI.Domain.Responses;
using HungryPizzaAPITest.Configuration;
using Moq;
using Xunit;

namespace HungryPizzaAPITest.Unit
{
    public class OrderControllerTest : IClassFixture<ApplicationFactory<Startup>>
    {
        private readonly IOrderService _orderService;
        private const string CustomerCpf = "00000000000";

        public OrderControllerTest()
        {
            var mockResponse = new List<OrderResponse> {OrderFixtures.GetMockOrderResponse()};
            var mockService = new Mock<IOrderService>();
            mockService.Setup(m => m.Get()).Returns(mockResponse);
            mockService.Setup(m => m.Get(CustomerCpf)).Returns(mockResponse);
            mockService.Setup(m => m.Place(new OrderRequest())).Returns(mockResponse.First());
            _orderService = mockService.Object;
        }

        [Fact]
        public void GetOrders()
        {
            var controller = new OrderController(_orderService);
            var response = controller.List();
            var val = response.Value as List<OrderResponse>;
            Assert.NotEmpty(val);
        }
        
        [Fact]
        public void GetOrdersOfCustomer()
        {
            var controller = new OrderController(_orderService);
            var response = controller.List(CustomerCpf);
            var val = response.Value as List<OrderResponse>;
            Assert.NotEmpty(val);
        }
        
        [Fact]
        public void PlaceOrder()
        {
            var controller = new OrderController(_orderService);
            var response = controller.Place(OrderFixtures.GetMockOrderRequest());
            var val = response.Value as List<OrderResponse>;
            Assert.NotEmpty(val);
        }
    }
}