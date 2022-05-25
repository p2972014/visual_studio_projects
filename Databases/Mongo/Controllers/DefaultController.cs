using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Mongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        public DefaultController()
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IEnumerable<string>> Get()
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("db1");
            var coll1=database.GetCollection("coll1");
            var ret = (await (await client.ListDatabasesAsync()).ToListAsync()).ToArray();
            return new[] { "" };
        }
    }
}