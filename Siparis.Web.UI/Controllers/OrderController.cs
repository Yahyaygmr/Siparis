using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Siparis.Web.UI.Models.Order;

namespace Siparis.Web.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44304/api/Orders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<OrderViewModel>>(jsonData);
                //values.Where(x => x.OrderStatus == "")
                values?.Reverse();
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> WatingForMeasure()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44304/api/Orders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<OrderViewModel>>(jsonData);
                var lValue = values?.Where(x => x.OrderStatus == "Ölçü Bekleniyor").ToList();
                lValue?.Reverse();
                return View(lValue);
            }
            return View();
        }
        public IActionResult WillBeCut()
        {
            return View();
        }
        public IActionResult WillBeSewn()
        {
            return View();
        }
        public IActionResult Ready()
        {
            return View();
        }
        public IActionResult Delivered()
        {
            return View();
        }
    }
}
