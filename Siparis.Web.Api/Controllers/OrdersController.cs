using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siparis.BussinessLayer.Abstract;
using Siparis.EntityLayer.Concrete;

namespace Siparis.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var orders = _orderService.TGetList();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public IActionResult OrderDetail(int id)
        {
            var order = _orderService.TGetById(id);
            return Ok(order);
        }
        [HttpPost]
        public IActionResult OrderAdd(Order order)
        {
            Guid guid = Guid.NewGuid(); // Rastgele bir Guid üretir.

            // Guid'in son 6 karakterini alarak, 6 haneli sayı oluşturur.
            string guidString = guid.ToString("N"); // N formatı, "-" karakterini çıkararak sadece rakamları alır.
            string sixDigitString = guidString.Substring(guidString.Length - 10);

            order.OrderDate = DateTime.Now;
            order.OrderNumber = sixDigitString;
            
            _orderService.TInsert(order);
            return Ok();
        }
        [HttpPut]
        public IActionResult OrderUpdate(Order order)
        {
            order.OrderDate = DateTime.Now;
            _orderService.TUpdate(order);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult OrderDelete(int id)
        {
            var values = _orderService.TGetById(id);
            _orderService.TDelete(values);
            return Ok();
        }

    }
}
