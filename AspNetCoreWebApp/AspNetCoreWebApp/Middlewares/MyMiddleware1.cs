using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AspNetCoreWebApp.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware1
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<MyMiddleware1> _logger;

        public MyMiddleware1(RequestDelegate next, ILogger<MyMiddleware1> logger)
        {
            _next = next;

            _logger = logger;
        }

        public
            async 
            Task
            //void
            InvokeAsync(HttpContext httpContext)
        {
            //https://quizdeveloper.com/tips/understand-and-custom-middleware-pipeline-in-aspdotnet-core-aid59

            //request

            _logger.LogInformation("MyMiddleware1. Invoke. request");

            await
                _next(httpContext);

            //response

            _logger.LogInformation("MyMiddleware1. Invoke. response");
        }
    }
}
