using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileService.IServiceInterfaces;
using ProfileService.Model;
using ProfileService.Services;
using RawRabbit;
using Vacation.common;
using Vacation.common.Events;

namespace ProfileService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly IPositionService _positionservice;
        private IBusClient _rawRabbitBus;
        public ValuesController(IPositionService positionservice, IBusClient rawRabbitBus)
        {
            _positionservice = positionservice;
            _rawRabbitBus = rawRabbitBus;
        }
        
        
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await _rawRabbitBus.PublishAsync<DemoRabbit>(new DemoRabbit
            {
                message = "OK"
            });

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
