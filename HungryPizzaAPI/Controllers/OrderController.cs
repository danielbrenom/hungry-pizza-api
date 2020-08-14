using HungryPizzaAPI.Domain.Models.Collections;
using HungryPizzaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Order = HungryPizzaAPI.Domain.Requests.Order;

namespace HungryPizzaAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet]
        public JsonResult List()
        {
            return Json(_orderService.Get());
        }
        
        [HttpGet("{cpf}")]
        public JsonResult List(string cpf = null)
        {
            return Json(_orderService.Get(cpf));
        }

        [HttpPost]
        public JsonResult Place(Order order)
        {
            var finishedOrder = _orderService.Create(order);
            return Json(finishedOrder);
        }
    }
}