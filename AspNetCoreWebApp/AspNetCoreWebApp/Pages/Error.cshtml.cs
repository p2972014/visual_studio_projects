using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace AspNetCoreWebApp.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId)
            //&& _hostEnvironment.IsDevelopment()
            ;

        public string ExceptionMessage { get; private set; }

        private readonly ILogger<ErrorModel> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ErrorModel(ILogger<ErrorModel> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;


            var exceptionHandlerPathFeature =
                HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                ExceptionMessage = "The file was not found.";
            }

            if (exceptionHandlerPathFeature?.Path == "/")
            {
                ExceptionMessage ??= string.Empty;
                ExceptionMessage += " Page: Home.";
            }

            ExceptionMessage += exceptionHandlerPathFeature?.Error?.Message;
        }
    }
}