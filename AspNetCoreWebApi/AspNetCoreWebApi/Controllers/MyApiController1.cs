using AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyApiController1 : ControllerBase
    {
        private readonly m_db1Context _context;

        public MyApiController1(
            m_db1Context context
            )
        {
            _context = context;
        }

        // GET: api/<MyApiController1>
        [HttpGet(Name = "GetMyApiController1")]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //    //return _context.MT1s.Take(10).ToArray();
        //}
        public IEnumerable<MRelMT1MT2> Get()
        {
            return _context.MRelMT1MT2s.Include(it => it.MT1M).Include(it => it.MT2M).Take(10).ToArray();
        }

        // GET api/<MyApiController1>/5
        [HttpGet("{id}", Name = null, Order = 10)]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MyApiController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MyApiController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MyApiController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
