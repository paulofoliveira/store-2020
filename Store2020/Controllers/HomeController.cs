using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store2020.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Store2020.Controllers
{
    public class HomeController : Controller
    {
        private static string ACCOUNT_SERVICE_API_BASE = Environment.GetEnvironmentVariable("ACCOUNT_SERVICE_API_BASE");
        private static string INVENTORY_SERVICE_API_BASE = Environment.GetEnvironmentVariable("INVENTORY_SERVICE_API_BASE");
        private static string SHOPPING_SERVICE_API_BASE = Environment.GetEnvironmentVariable("SHOPPING_SERVICE_API_BASE");

        public HomeController()
        {
            if (ACCOUNT_SERVICE_API_BASE == null)
            {
                ACCOUNT_SERVICE_API_BASE = "http://localhost:5001/api";
            }

            if (INVENTORY_SERVICE_API_BASE == null)
            {
                INVENTORY_SERVICE_API_BASE = "http://localhost:5002/api";
            }

            if (SHOPPING_SERVICE_API_BASE == null)
            {
                SHOPPING_SERVICE_API_BASE = "http://localhost:5003/api";
            }
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();

            var user = new Consumer();
            HttpResponseMessage res1 = await client.GetAsync($"{ACCOUNT_SERVICE_API_BASE}/consumers/5");
            if (res1.IsSuccessStatusCode)
            {
                var result = res1.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<Consumer>(result);
            }
                
            var products = new List<Product>();
            HttpResponseMessage res2 = await client.GetAsync($"{INVENTORY_SERVICE_API_BASE}/products");
            if(res2.IsSuccessStatusCode){
                var result = res2.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(result);
            }

            var cart = default(Cart);

            HttpResponseMessage res3 = await client.GetAsync($"{SHOPPING_SERVICE_API_BASE}/cart/30");
            if (res3.IsSuccessStatusCode)
            {
                var result = res3.Content.ReadAsStringAsync().Result;
                cart = JsonConvert.DeserializeObject<Cart>(result);
            }

            var commerce = new Commerce()
            {
                User = user,
                Products = products,
                Cart = cart
            };

            return View(commerce);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
