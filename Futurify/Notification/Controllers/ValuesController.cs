using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notification.Handles;
using RawRabbit;
using RawRabbit.Context;
using Vacation.common.Events;


namespace Notification.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IBusClient _rawRabbitBus;
        public ValuesController( IBusClient rawRabbitBus)
        {
            _rawRabbitBus = rawRabbitBus;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            
            var messageHandler = new DemoHandler();
            _rawRabbitBus.SubscribeAsync<DemoRabbit>(messageHandler.HandleAsync);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
