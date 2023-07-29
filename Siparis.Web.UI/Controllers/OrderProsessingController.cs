using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Siparis.Web.UI.Models.Order;

namespace Siparis.Web.UI.Controllers
{
    public class OrderProsessingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment _environment;

        public OrderProsessingController(IHttpClientFactory httpClientFactory, IWebHostEnvironment environment)
        {
            _httpClientFactory = httpClientFactory;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderViewModel model)
        {
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(_environment.WebRootPath, @"images");
                var ext = Path.GetExtension(files[0].FileName);
                if (model.OrderImageUrl != null)
                {
                    var imagePath = Path.Combine(_environment.WebRootPath, model.OrderImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                {
                    files[0].CopyTo(filesStreams);
                }
                model.OrderImageUrl = @"\images\" + fileName + ext;
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44304/api/Orders", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Order");
            }
            return View();
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // API'den siparişi al
            var getOrderResponse = await client.GetAsync($"https://localhost:44304/api/Orders/{id}");
            if (getOrderResponse.IsSuccessStatusCode)
            {
                var orderData = await getOrderResponse.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<OrderViewModel>(orderData);

                // Siparişin ilişkili bir görsel URL'si varsa, görseli sil
                if (!string.IsNullOrEmpty(order.OrderImageUrl))
                {
                    var imagePath = Path.Combine(_environment.WebRootPath, order.OrderImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
            }

            // Siparişi sil
            var responseMessage = await client.DeleteAsync($"https://localhost:44304/api/Orders/{id}");

            // Sipariş silme başarılıysa, sipariş index sayfasına yönlendir
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Order");
            }

            // Sipariş silme başarısız olursa, ilgili görünümü döndür
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44304/api/Orders/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateOrderViewModel>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderViewModel model)
        {
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(_environment.WebRootPath, @"images");
                var ext = Path.GetExtension(files[0].FileName);
                if (model.OrderImageUrl != null)
                {
                    var imagePath = Path.Combine(_environment.WebRootPath, model.OrderImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                {
                    files[0].CopyTo(filesStreams);
                }
                model.OrderImageUrl = @"\images\" + fileName + ext;
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44304/api/Orders/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var targetUrl = Url.Action("Detail", "Order", new { id = model.OrderId });

                // Oluşturulan URL'ye yönlendirme yapın
                return Redirect(targetUrl);
            }
            return View();
        }
    }
}
