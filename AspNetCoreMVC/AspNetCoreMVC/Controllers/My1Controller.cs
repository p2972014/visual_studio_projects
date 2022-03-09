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

        //[HttpGet]
        //public IActionResult Page3(int id)
        //{
        //    return View(new Page3ViewModel());
        //}
        //[HttpPost]
        public IActionResult Page3(Page3ViewModel model, int? id)
        {
            if (id != null)
            {
                model.m_str1 = @"id=" + id;
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //---

        [HttpPost]
        public IActionResult Page3Post(Page3ViewModel model)
        {
            model.m_str1 = "vsl_btn1_click. " + DateTime.Now;
            return
                //RedirectToPage(@"Page3");
                View("Page3", model);
        }
    }
}