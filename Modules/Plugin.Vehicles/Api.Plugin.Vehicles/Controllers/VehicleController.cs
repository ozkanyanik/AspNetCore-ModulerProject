using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Plugin.Vehicles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        // GET api/Vehicles
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Vehicles1", "Vehicles2" };
        }

        // GET api/Vehicles/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Vehicles";
        }

        // POST api/Vehicles
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Vehicles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Vehicles/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
