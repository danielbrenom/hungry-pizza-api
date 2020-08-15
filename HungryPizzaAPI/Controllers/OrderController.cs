using HungryPizzaAPI.Domain.Requests;
using HungryPizzaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizzaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public JsonResult List(string cpf)
        {
            return Json(_orderService.Get(cpf));
        }

        [HttpPost]
        public JsonResult Place(OrderRequest orderRequest)
        {
            var finishedOrder = _orderService.Place(orderRequest);
            return new JsonResult(finishedOrder)
            {
                StatusCode = 201
            };
        }
    }
}