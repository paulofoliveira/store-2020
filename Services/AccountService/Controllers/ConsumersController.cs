using AccountService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    public class ConsumersController : Controller
    {
        // GET: api/consumers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value100", "value200" };
        }

        // GET: api/consumers/5
        [HttpGet("{id}")]
        public ActionResult<Consumer> Get(int id)
        {
            var consumer = new Consumer()
            {
                Firstname = "Jeremy",
                Surname = "Cook",
                Age = 20
            };

            return consumer;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
