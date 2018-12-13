using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Plugin.Drivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        // GET api/Drivers
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Drivers1", "Drivers2" };
        }

        // GET api/Drivers/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Drivers";
        }

        // POST api/Drivers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Drivers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Drivers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
