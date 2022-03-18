using AspNetCoreGrpc;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static AspNetCoreGrpc.GrpcMy;

namespace AspNetCoreGrpcClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController1>
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            var tmp_url ="http://localhost:5264";
            using var channel = GrpcChannel.ForAddress(tmp_url);
            var client = new GrpcMyClient(channel);
            var tmp = await client.GrpcMySayHelloAsync(new GrpcMyHelloRequest() { MField1Name = $"ValuesController. Get. {DateTime.Now}" });
            return new string[] { "value1", "value2", tmp.MField1Message };
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "value";
        }
    }
}