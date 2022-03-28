using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAppOAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "ValuesController";
        }
    }
}
