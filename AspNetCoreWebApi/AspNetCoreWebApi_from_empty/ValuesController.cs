using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreWebApi_from_empty
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {
                "this assembly: " + this?.GetType()?.Assembly?.FullName,
                "value1", "value2" };
        }

        // http://localhost:5158/api/Values/get2
        [Route("get2")]
        [HttpGet]
        public string Get2()
        {
            return "Route get2";
        }

        //http://localhost:5158/api/Values/custom/url/to/destination
        [Route("custom/url/to/destination")]
        [HttpGet]
        public string Get3()
        {
            return "Route get3";
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
