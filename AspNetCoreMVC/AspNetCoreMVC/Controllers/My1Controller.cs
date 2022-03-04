using AspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreMVC.Controllers
{
    public class My1Controller : Controller
    {
        private readonly ILogger<My1Controller> _logger;

        public My1Controller(ILogger<My1Controller> logger)
        {
            _logger = logger;
        }

        public IActionResult Page3()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}