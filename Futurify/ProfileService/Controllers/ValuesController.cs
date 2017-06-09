using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileService.IServiceInterfaces;
using ProfileService.Model;
using ProfileService.Services;

namespace ProfileService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IPositionService _positionservice;

        public ValuesController(IPositionService positionservice)
        {
            _positionservice = positionservice;
        }
        
        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _positionservice.CreateAsync();
            var position = _positionservice.GetAsync(1);
            //return new string[] { "value1", "value2" };
            return new string[] { position.Result.PositionName };
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
