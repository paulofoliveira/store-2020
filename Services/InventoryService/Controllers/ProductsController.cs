using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = new List<Product>(){
                new Product()
                    {
                        Description = "",
                        Id = 1,
                        Sku = "abc12300",
                        Name = "Toy1",
                        DiscountPrice = 20.99m,
                        RegularPrice = 29.99m,
                        Quantity = 100
                    },
                    new Product()
                    {
                        Description = "",
                        Id = 2,
                        Sku = "xyz123",
                        Name = "Toy2",
                        DiscountPrice = 20.99m,
                        RegularPrice = 29.99m,
                        Quantity = 100
                    }
            };

            return products;
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
