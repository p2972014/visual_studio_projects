using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreWebApp.Pages
{
    public class Page1Model : PageModel
    {
        public string Message { get; set; } = "Initial Request";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Message = "Form Posted";
        }
        public void OnPostMyhandler1(int id)
        {
            Message = "Myhandler1";
        }
        public void OnPostMyhandler3(int id)
        {
            Message = "Myhandler3";
        }
    }
}
