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
        public JsonResult Index()
        {
            return Json("Ola");
        }
        
        [HttpGet]
        public JsonResult List()
        {
            return Json(_orderService.Get());
        }

        [HttpPost]
        public JsonResult Place(Order order)
        {
            
            return Json(order);
        }
    }
}